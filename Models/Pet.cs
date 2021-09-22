using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public class Pet 
    {
        public int id {get; set;}
        public enum PetBreedType 
        {
            Shepherd, 
            Poodle, 
            Beagle, 
            Bulldog, 
            Terrier, 
            Boxer, 
            Labrador, 
            Retriever
        }
        public enum PetColorType 
        {
            White,
            Black, 
            Golden, 
            Tricolor, 
            Spotted
        }
        
        [ForeignKey("PetOwner")]
        public int PetOwnerId {get; set;}

    }
  
}
