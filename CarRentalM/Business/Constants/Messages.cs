using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages { 
        public static string AddedMessage = " added.";
      
        public static string DeletedMessage = " deleted.";

        public static string UpdatedMessage = " updated.";
    
        public static string ListedMessage = " listed.";
      
        public static string DailyPriceSmallerThanZero = "The daily price of car can't be smaller than 0.";
        public static string RentaledMessage = " rentaled.";

        public static string AccessTokenCreated = "Access Token Created";
        public static string UserAlreadyExists = "User Already Exists";
        public static string SuccessfulLogin = "Successfull login";
        public static string PasswordError = "The password is incorrect";

        public static string UserNotFound = "User is not found";

        public static string AuthorizationDenied = "Authorization denied";

        public static string UserRegistired = "Registired";

        public static string ImagesAdded = "Images are added";
        public static string ImageNotFound = "Image is not found";
        public static string UnsupportedFile = " Unsupported file";
        public static string ImageNoLimit = "Image no limit";
        public static string ImageDeleted = "Image is deleted";
    }
}
