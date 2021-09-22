using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public class Pet 
    {
        public int id {get; set;}
        public enum PetBreedType {}
        public enum PetColorType {}
        
        [ForeignKey("PetOwner")]
        public int PetOwnerId {get; set;}

    }
  
}
