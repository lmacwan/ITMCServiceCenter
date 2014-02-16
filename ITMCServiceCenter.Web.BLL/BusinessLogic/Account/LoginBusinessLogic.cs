using ITMCServiceCenter.Web.Domain;

namespace ITMCServiceCenter.Web.BLL
{
    public class LoginBusinessLogic
    {
        public tbl_UserMaster_DTO AuthenticateUser(tbl_UserMaster_DTO userToAuthenticate)
        {
            tbl_UserMaster_DTO userdetail = null;
            var accoutnDetails = ServiceReference.ITMCServiceClient.AuthenticateUser(userToAuthenticate);
            if (accoutnDetails.Success)
            {
                userdetail = ValidateUserAccount(accoutnDetails.Value);
            }
            return userdetail;
        }

        private tbl_UserMaster_DTO ValidateUserAccount(tbl_UserMaster_DTO userMasterDTO)
        {
            if (userMasterDTO == null)
            {
                userMasterDTO = new tbl_UserMaster_DTO();
            }
            else if (userMasterDTO.IsDisable)
            {
                userMasterDTO.ModelMessage.Add(new ModelMessage { Code = ErrorCode.Disabled, Message = Domain.Resources.ITMCServiceCenterResource.msgUserDisabled, Type = MessageType.Error });
            }
            return userMasterDTO;
        }
    }
}
