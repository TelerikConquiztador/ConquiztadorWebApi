namespace GameDb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        public Game()
        {
            this.Id = Guid.NewGuid();
            this.Map = "000000\n00000\n0000\n000\n";
        }

        [Key]
        public Guid Id { get; set; }

        public string Map { get; set; }

        [Required]
        public string PlayerId { get; set; }

        /// <summary>
        /// The red player
        /// </summary>
        public virtual User Player { get; set; }

        public int Score { get; set; }
    }
}
