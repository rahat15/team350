﻿using Microsoft.EntityFrameworkCore;
using SeamlessEscapesBlazor.Models;
using System;

namespace SeamlessEscapesBlazor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Password).IsRequired();
            });

            modelBuilder.Entity<Flight>().HasData(
                new Flight
                {
                    FlightId = 1,
                    FlightNumber = "AA123",
                    Airline = "American Airlines",
                    DepartureTime = new DateTime(2024, 6, 15, 8, 0, 0),
                    ArrivalTime = new DateTime(2024, 6, 15, 12, 0, 0),
                    Description = "Non-stop flight from NYC to LA"
                },
                new Flight
                {
                    FlightId = 2,
                    FlightNumber = "DL456",
                    Airline = "Delta Airlines",
                    DepartureTime = new DateTime(2024, 6, 16, 9, 0, 0),
                    ArrivalTime = new DateTime(2024, 6, 16, 13, 0, 0),
                    Description = "Non-stop flight from NYC to LA"
                }
            );
        }
    }
}