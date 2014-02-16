using ITMCServiceCenter.Web.Domain;
using ITMCServiceCenter.Web.Domain.Resources;
using System.ComponentModel.DataAnnotations;

namespace ITMCServiceCenter.Web.UI
{
    public class LoginModel : CommonModel
    {
        [Required(ErrorMessageResourceName = "validationRequiredUserName", ErrorMessageResourceType = typeof(ITMCServiceCenterResource))]
        [Display(ResourceType = typeof(ITMCServiceCenterResource), Name = "lblUserName")]
        public string UserName { get; set; }

        [Display(ResourceType = typeof(ITMCServiceCenterResource), Name = "lblPassword")]
        [Required(ErrorMessageResourceName = "validationRequiredPassword", ErrorMessageResourceType = typeof(ITMCServiceCenterResource))]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}