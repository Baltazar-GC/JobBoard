using backend.Contexts;
using backend.Entities;
using backend.Models;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace backend.Repositories.Implementations
{
    public class ApproveEmployersRepository : Repository, IApproveEmployersRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IBusinessInformationService _businessInformationService;
        private readonly IBusinessContactService _businessContactService;



        public ApproveEmployersRepository(ApplicationUtnContext context, IBusinessInformationService businessInformationService, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IBusinessContactService businessContactService) : base(context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _businessInformationService = businessInformationService;
            _businessContactService = businessContactService;
        }
        //get all employers
        public async Task<ICollection<EmployerToApproveDto?>> GetEmployers()
        {
            var employers = new List<EmployerToApproveDto>();

            var users = _context.Users.ToList();

            foreach (var user in users)
            {

                var isInRole = await _userManager.IsInRoleAsync(user, "Employer");

                if (isInRole)
                {
                    var binfo = _businessInformationService.GetBusinessInformation(user.Id);
                    var cinfo = _businessContactService.GetBusinessContact(user.Id);

                    employers.Add(new EmployerToApproveDto()
                    {
                        Employer = user,
                        BusinessInformation = binfo,
                        BusinessContact = cinfo
                    });

                }

            }
            return employers;

        }


        //get not approved employers
        public async Task<ICollection<EmployerToApproveDto?>> GetNotApprovedEmployers()
        {
            var notApprovedEmployers = new List<EmployerToApproveDto>();

            var users = _context.Users.ToList();

            foreach (var user in users)
            {

                var isInRoleApproved = await _userManager.IsInRoleAsync(user, "ApprovedEmployer");
                var isInRoleEmployer = await _userManager.IsInRoleAsync(user, "Employer");


                if (!isInRoleApproved && isInRoleEmployer)
                {
                    var binfo = _businessInformationService.GetBusinessInformation(user.Id);
                    var cinfo = _businessContactService.GetBusinessContact(user.Id);

                    notApprovedEmployers.Add(new EmployerToApproveDto()
                    {
                        Employer = user,
                        BusinessInformation = binfo,
                        BusinessContact = cinfo
                    });
                }
            }

            return notApprovedEmployers;
        }


        //get approved employers
        public async Task<ICollection<EmployerToApproveDto?>> GetApprovedEmployers()
        {
            var approvedEmployers = new List<EmployerToApproveDto>();

            var users = _context.Users.ToList();

            foreach (var user in users)
            {

                var isInRole = await _userManager.IsInRoleAsync(user, "ApprovedEmployer");

                if (isInRole)
                {
                    var binfo = _businessInformationService.GetBusinessInformation(user.Id);
                    var cinfo = _businessContactService.GetBusinessContact(user.Id);

                    approvedEmployers.Add(new EmployerToApproveDto()
                    {
                        Employer = user,
                        BusinessInformation = binfo,
                        BusinessContact = cinfo
                    });
                }
            }

            return approvedEmployers;
        }

        public async Task<bool> ApproveEmployer(string employerId)
        {
            var employerToApprove = await _userManager.FindByIdAsync(employerId);

            if (employerToApprove is null)
                return false;

            if (!await _roleManager.RoleExistsAsync("ApprovedEmployer"))
                await _roleManager.CreateAsync(new IdentityRole("ApprovedEmployer"));

            await _userManager.AddToRoleAsync(employerToApprove, "ApprovedEmployer");

            return true;
        }


        public async Task<bool> DisapproveEmployer(string employerId)
        {
            var employerToApprove = await _userManager.FindByIdAsync(employerId);

            if (employerToApprove is null)
                return false;

            if (!await _roleManager.RoleExistsAsync("ApprovedEmployer"))
                await _roleManager.CreateAsync(new IdentityRole("ApprovedEmployer"));

            await _userManager.RemoveFromRoleAsync(employerToApprove, "ApprovedEmployer");

            return true;
        }
    }
}
