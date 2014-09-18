namespace GameDb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public Game()
        {
            this.Id = Guid.NewGuid();
            this.Map = "000000\n00000\n0000\n000\n";
            this.State = GameState.WaitingForSecondPlayer;
        }

        [Key]
        public Guid Id { get; set; }

        public string Map { get; set; }

        public GameState State { get; set; }

        [Required]
        public string RedPlayerId { get; set; }

        /// <summary>
        /// The red player
        /// </summary>
        public virtual User RedPlayer { get; set; }

        public string GreenPlayerId { get; set; }

        /// <summary>
        /// The green player
        /// </summary>
        public virtual User GreenPlayer { get; set; }
    }
}
