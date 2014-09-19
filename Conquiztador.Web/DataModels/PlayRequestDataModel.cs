namespace Conquiztador.Web.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class PlayRequestDataModel
    {
        [Required]
        public string UserName { get; set; }

        public int Score { get; set; }
    }
}