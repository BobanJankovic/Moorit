
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moorit.Data;
using Moorit.Models;
using Moorit.Repository;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace Moorit.Infrastructure
{
    public class DataSeedClass
    {
        private readonly ModelBuilder modelBuilder;
        //private readonly ILocationRepository _locationRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        public readonly IAccountRepository _accountRepository;
        private readonly UserManager<ApplicationUserModel> _userManager;
        //private readonly IMooringRepository _mooringRepository;
        //private readonly IBookingRepository _bookingRepository;

        public DataSeedClass(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public DataSeedClass(
            ModelBuilder modelBuilder,  
            //RoleManager<IdentityRole> roleManager,
            IAccountRepository accountRepository,
            //ILocationRepository locationRepository, 
       
            UserManager<ApplicationUserModel> userManager
            //IMooringRepository mooringRepository,
            //IBookingRepository bookingRepository
            )
        {
            this.modelBuilder = modelBuilder;
            //this._roleManager = roleManager;
           _accountRepository = accountRepository;
            //this._locationRepository = locationRepository;
          
            _userManager = userManager;
            //this._mooringRepository = mooringRepository;
            //this._bookingRepository = bookingRepository;
        }

      

        async public void Seed()
        {
            var userSignUp = new SignUpModel()
            {
                FirstName = "Boban",
                LastName = "Jankovic",
                Email = "boban0092@gmail.com",
                Password = "INTcdrd2025BobanINTcdrd2025Bob@n",
                ConfirmPassword = "INTcdrd2025BobanINTcdrd2025Bob@n"

            };

            var user = new ApplicationUserModel()
            {
                FirstName = "Boban",
                LastName = "Jankovic",
                Email = "boban0092@gmail.com",
                UserName = "boban0092@gmail.com",
            };

            var aaa = await _userManager.CreateAsync(user, "INTcdrd2025BobanINTcdrd2025Bob@n");

            //var createUser=await _roleManager.CreateAsync(new IdentityRole("User"));
            //var createAdmin= await _roleManager.CreateAsync(new IdentityRole("Admin"));

            //var userSignUp = new SignUpModel()
            //{
            //    FirstName = "Boban",
            //    LastName = "Jankovic",
            //    Email = "boban0092@gmail.com",
            //    Password = "INTcdrd2025BobanINTcdrd2025Bob@n",
            //    ConfirmPassword = "INTcdrd2025BobanINTcdrd2025Bob@n"

            //};

            //    var createsignUp = await _accountRepository.SignUpAsync(userSignUp);

            //    var user = await _userManager.FindByEmailAsync(userSignUp.Email);

            //   var assignUser= await _userManager.AddToRoleAsync(user, "User");
            //    var assignAdmin = await _userManager.AddToRoleAsync(user, "Admin");

            //    LocationModel location1 = new LocationModel()
            //    {
            //        Name="Pag",
            //        Latitude = 44,
            //        Longitude = 44,
            //    };

            //    LocationModel location2 = new LocationModel()
            //    {
            //        Name = "Zadar",
            //        Latitude = 44,
            //        Longitude = 44,
            //    };

            //    LocationModel location3 = new LocationModel()
            //    {
            //        Name = "Zrce",
            //        Latitude = 44,
            //        Longitude = 44,
            //    };

            //    var location11 = await _locationRepository.AddLocationAsync(location1);
            //    var location22= await _locationRepository.AddLocationAsync(location2);
            //    var location33= await _locationRepository.AddLocationAsync(location3);


            //    var mooring = new MooringModel()
            //    {
            //        Name = "Pag moor 333",
            //        Length = 120,
            //        Width = 130,
            //        IsOccupied = true,
            //        Latitude = 45,
            //        Longitude = 14,
            //        Price = 170,
            //        Location = location1
            //    };

            //    var booking = new BookingModel()
            //    {
            //        StartDate = new DateTime(),
            //        EndDate = new DateTime(),
            //        Price = 666,
            //        User = user,
            //        Mooring = mooring
            //    };

            //   var moor1= await _mooringRepository.AddMooringAsync(mooring);

            //    var moor2 = await _bookingRepository.AddBookingAsync(booking);
            Console.WriteLine("aaa");
        }
    }
}


//const initialMarkers = [
//          {
//            // Pula
//            position: { lat: 44.866623, lng: 13.849579 },
//            draggable: false,
//          },
//          {
//// Pula
//position: { lat: 44.803032047087775, lng: 13.886718750000002 },
//            draggable: false,
//          },
//          {
//// Pula
//position: { lat: 44.83149565235624, lng: 13.84208679199219 },
//            draggable: false,
//          },
    
//          {
//// Cres
//position: { lat: 44.791, lng: 14.468994140625 },
//            draggable: false,
//          },
//          {
//// Cres
//position: { lat: 44.81094847061471, lng: 14.355010986328125 },
//            draggable: false,
//          },
//          {
//// Cres
//position: { lat: 44.66950744598924, lng: 14.403076171875002 },
//            draggable: false,
//          },
//          {
//// Krk
//position: { lat: 45.0278995, lng: 14.575211399999944 },
//            draggable: false,
//          },
//          {
//// Krk
//position: { lat: 44.96066822746151, lng: 14.642028808593752 },
//            draggable: false,
//          },
//          {
//// Krk
//position: { lat: 45.0210051795428, lng: 14.493713378906252 },
//            draggable: false,
//          },
    
//          {
//// Rab
//position: { lat: 44.84016893046839, lng: 14.716186523437502 },
//            draggable: false,
//          },
//          {
//// Rab
//position: { lat: 44.74563596522479, lng: 14.757385253906252 },
//            draggable: false,
//          },
//          {
//// Rab
//position: { lat: 44.71246404871097, lng: 14.864501953125002 },
//            draggable: false,
//          },
    
//          {
//// Pag
//position: { lat: 44.55610550374227, lng: 14.874114990234377 },
//            draggable: false,
//          },
//          {
//// Pag
//position: { lat: 44.461108019989624, lng: 14.963378906250002 },
//            draggable: false,
//          },
//          {
//// Pag
//position: { lat: 44.53457325846243, lng: 14.941406250000002 },
//            draggable: false,
//          },
    
//          {
//// Zadar
//position: { lat: 44.121544542898526, lng: 15.221557617187502 },
//            draggable: false,
//          },
//          {
//// Zadar
//position: { lat: 44.089434505800256, lng: 15.257263183593752 },
//            draggable: false,
//          },
//          {
//// Zadar
//position: { lat: 44.07266379452475, lng: 15.281982421875002 },
//            draggable: false,
//          },
//        ];