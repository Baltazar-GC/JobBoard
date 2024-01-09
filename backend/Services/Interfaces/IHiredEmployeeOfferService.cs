using backend.Models;
using backend.Models.HiredEmployeeOffer;

namespace backend.Services.Interfaces
{
    public interface IHiredEmployeeOfferService
    {
        public bool AddHiredEmployeeOffer(HiredEmployeeOfferToCreationDto newHiredEmployeeOffer, string userId);
        public bool UpdateHiredEmployeeOffer(HiredEmployeeOfferToUpdateDto updatedHiredEmployeeOffer, int hiredEmployeeOfferId);

        public HiredEmployeeOfferDto? GetHiredEmployeeOffer(int hiredEmployeeOfferId);

        public bool DeleteHiredEmployeeOffer(int hiredEmployeeOfferId);

        public ICollection<HiredEmployeeOfferDto>? GetAll();

        public ICollection<HiredEmployeeOfferDto>? GetAllByEmployerId(string userId);

        public HiredEmployeeOfferDto? GetHiredEmployeeOfferByEmployerId(string userId, int hiredEmployeeOfferId);


    }
}
