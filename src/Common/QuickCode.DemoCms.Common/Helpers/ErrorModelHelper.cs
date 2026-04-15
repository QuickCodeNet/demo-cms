using QuickCode.DemoCms.Common.Models;

namespace QuickCode.DemoCms.Common.Helpers
{
    public static class ErrorModelHelper
	{
        public static ErrorModel CreateErrorModel(string errorCode, params string[] detailErrorCodes)
        {
            var errorModel = new ErrorModel
            {
                ErrorCode = errorCode
            };
            
            if (detailErrorCodes.Length != 0)
            {
                errorModel.DetailErrorCodes = detailErrorCodes.ToList();
            }
            return errorModel;
        }
    }
}

