namespace Conquiztador.Web.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class PlayRequestDataModel
    {
        [Required]
        public string GameId { get; set; }

        public int Answer { get; set; }
    }
}