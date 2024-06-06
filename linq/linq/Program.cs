using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using linq;

// ReSharper disable UseFormatSpecifierInInterpolation

namespace FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath = @"D:\Dataset\googleplaystore1.csv";
            var googleApps = LoadGoogleAps(csvPath);

            //Display(googleApps);
            //GetData(googleApps);
            //ProjectData(googleApps);
            DivideData(googleApps);

        }

        static void DivideData(IEnumerable<GoogleApp> googleApps)
        {
            var highRatedBeautyApps = googleApps.Where(app => app.Rating > 4.4m && app.Category == Category.BEAUTY);

            var first5HighRatedApps = highRatedBeautyApps.Take(5);
            var last5HighRatedApps = highRatedBeautyApps.TakeLast(5);
            var appsWithReviesWhile1000 = highRatedBeautyApps.TakeWhile(app => app.Reviews > 1000);
            var skippedResults = highRatedBeautyApps.Skip(5);
            var skippedResultsWhileReviewsOver1000 = highRatedBeautyApps.SkipWhile(app => app.Reviews > 1000);

            Display(highRatedBeautyApps);
            Console.WriteLine("*****");
            Display(first5HighRatedApps);
            Console.WriteLine("*****");
            Display(last5HighRatedApps);
            Console.WriteLine("*****");
            Display(appsWithReviesWhile1000);
            Console.WriteLine("*****");
            Display(skippedResults);
            Console.WriteLine("*****");
            Display(skippedResultsWhileReviewsOver1000);
        }

        static void ProjectData(IEnumerable<GoogleApp> googleApps)
        {
            var highRatedBeautyApps = googleApps.Where(app => app.Rating > 4.6m && app.Category == Category.BEAUTY);
            var highRatedBeautyAppsNames = highRatedBeautyApps.Select(app => app.Name).ToList();

            var dtos = highRatedBeautyApps.Select(app => new GoogleAppDto()
            {
                Reviews = app.Reviews,
                Name = app.Name
            });

            var anonymousDtos = highRatedBeautyApps.Select(app => new
            {
                Reviews = app.Reviews,
                Name = app.Name,
                Category = app.Category
            });

            foreach (var dto in anonymousDtos)
            {
                Console.WriteLine(dto.Name + ":  " + dto.Reviews);
            }

            //foreach (var dto in dtos)
            //{
            //    Console.WriteLine(dto.Name + ": " + dto.Reviews );
            //}

            //var genres = highRatedBeautyApps.SelectMany(app => app.Genres);
            //Console.WriteLine(string.Join(";", genres));

            //Console.WriteLine(string.Join(", ", highRatedBeautyAppsNames));
        }

        static void GetData(IEnumerable<GoogleApp> googleApps)
        {
            var highRatedApps = googleApps.Where( app => app.Rating > 4.6m);
            var highRatedBeautyApps = googleApps.Where(app => app.Rating >4.6m && app.Category == Category.BEAUTY );
            Display(highRatedBeautyApps);

            var firstHighRatedBeautyApp = highRatedBeautyApps.SingleOrDefault(app => app.Reviews < 30);
            Console.WriteLine("firstHighRatedBeautyApp:");
            Console.WriteLine(firstHighRatedBeautyApp);
        }

        static void Display(IEnumerable<GoogleApp> googleApps)
        {
            foreach (var googleApp in googleApps)
            {
                Console.WriteLine(googleApp);
            }

        }
        static void Display(GoogleApp googleApp)
        {
            Console.WriteLine(googleApp);
        }

        static List<GoogleApp> LoadGoogleAps(string csvPath)
        {
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<GoogleAppMap>();
                var records = csv.GetRecords<GoogleApp>().ToList();
                return records;
            }

        }

    }


}

