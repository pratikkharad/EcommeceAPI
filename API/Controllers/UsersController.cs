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
    public class UsersController : ControllerBase
    {
        private readonly IUsersData dataview;
        private readonly ILogger<UsersController> logger;
        public UsersController(ILogger<UsersController> _logger, IUsersData _dataview)
        {
            logger = _logger;
            dataview = _dataview;
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<ResultModel> Insert(UsersEntity entity)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                var data = await dataview.Insert(entity);
                if (data.Message == "Success")
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


        [HttpPut]
        [Route("Update")]
        public async Task<ResultModel> Update(UsersEntity entity)
        {
            try
            {
                var data = await dataview.Update(entity);
                if (data.Message == "Success")
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

        [HttpDelete]
        [Route("Delete")]
        public async Task<ResultModel> Delete(UsersEntity entity)
        {
            try
            {
                var data = await dataview.Delete(entity);
                if (data.Message == "Success")
                {
                    return new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.Success,
                        Message = Convert.ToString(data.Message),
                        Details = Convert.ToString(data.Details),
                    };
                }
                else
                {
                    return new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.Error,
                        Message = Convert.ToString(data.Message),
                        Details = Convert.ToString(data.Details),
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

        [HttpGet]
        [Route("FindByID")]
        public async Task<ResultModel> FindByID(int ID)
        {
            try
            {
                var data = await dataview.FindByID(ID);
                if (data[0].Message == "Success")
                {
                    return new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.Success,
                        Message = Convert.ToString(data[0].Message),
                        Details = Convert.ToString(data[0].Details),
                        Data = data,
                    };
                }
                else
                {
                    return new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.Error,
                        Message = Convert.ToString(data[0].Message),
                        Details = Convert.ToString(data[0].Details),
                        Data = data,
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

        [HttpGet]
        [Route("FindAll")]
        public async Task<ResultModel> FindAll()
        {
            try
            {
                var data = await dataview.FindAll();
                if (data[0].Message == "Success")
                {
                    return new ResultModel()
                    {
                        Status = (int)ResponseStatusCode.Success,
                        Message = Convert.ToString(data[0].Message),
                        Details = Convert.ToString(data[0].Details),
                        Data = data
                    };
                }
                else
                {
                    return new ResultModel()
                    {
                        Result = string.Empty,
                        Status = (int)ResponseStatusCode.Error,
                        Message = Convert.ToString(data[0].Message),
                        Details = Convert.ToString(data[0].Details),
                        Data = data
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Result = string.Empty,
                    Status = (int)ResponseStatusCode.Error,
                    Message = CommonMessage.CannotInsertMessage,
                };
            }
        }

    }
}
