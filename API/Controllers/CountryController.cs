using Domain.Entities;
using Domain.Specification.Common;
using Domain.Specification.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryData dataview;
        private readonly ILogger<CountryController> logger;
        public CountryController(ILogger<CountryController> _logger, ICountryData _dataview)
        {
            logger = _logger;
            dataview = _dataview;
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<ResultModel> Insert(CountryEntity entity)
        {
            ResultModel resultModel = new ResultModel();    
            try
            {
                var data = await dataview.Insert(entity);
                if (data.Message == "Success" )
                {
                    return new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.Success,
                        Message = Convert.ToString(data.Message),
                        Details = Convert.ToString(data.Details)
                    };

                }
                else
                {
                    return new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.Error,
                        Message = Convert.ToString(data.Message),
                        Details = Convert.ToString(data.Details)
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Status = (int)ResponseStatusCode.Error,
                    Message = CommonMessage.CannotInsertMessage
                };
            }
         
        }

    }
}
