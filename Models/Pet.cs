using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
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

    public class Pet 
    {
        public int id { get; set; }

        public PetBreedType PetBreed { get; set; }
        
        public PetColorType PetColor { get; set; }
        

        [DataType(DataType.Date)]
        public DateTime CheckedInAt { get; set; }

        [ForeignKey("PetOwner")]
        public int PetOwnerId { get; set; }
    }
  
}
