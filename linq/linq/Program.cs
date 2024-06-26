﻿using System;
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
            //DivideData(googleApps);
            //OrderData(googleApps);
            //DataSetOperation(googleApps);
            //DataVerification(googleApps);
            //GroupData(googleApps);
            GroupDataOperations(googleApps);
        }

        static void GroupDataOperations(IEnumerable<GoogleApp> googleApps)
        {
            var categoryGroup = googleApps
                .GroupBy(g => g.Category);

            foreach (var group in categoryGroup)
            {
                var averageReviews = group.Average(e => e.Reviews);
                var minReviews = group.Min(e => e.Reviews);
                var maxReviews = group.Max(e => e.Reviews);

                var summedReviews = group.Sum(e => e.Reviews);

                var allAppsFromGroupHaveRatingMinThree = group.All(e => e.Rating > 3.0m);

                Console.WriteLine($"Category: {group.Key}");
                Console.WriteLine($"averageReviews: {averageReviews}");
                Console.WriteLine($"minReviews: {minReviews}");
                Console.WriteLine($"maxReviews: {maxReviews}");
                Console.WriteLine($"summedReviews: {summedReviews}");
                Console.WriteLine($"allAppsFromGroupHaveRatingMinThree: {allAppsFromGroupHaveRatingMinThree}");
                Console.WriteLine(" ");
            }

        }

        public static void GroupData(IEnumerable<GoogleApp> googleApps)
        {
            var categoryGroup = googleApps.GroupBy(g => new { g.Category, g.Type });

            foreach (var group in categoryGroup)
            {
                //var apps = artAndDesignGroup.Select(e => e)
                var apps = group.ToList();
                Console.WriteLine(" ");
                Console.WriteLine($"Displaying elements for group {group.Key.Category}, {group.Key.Type}");
                Console.WriteLine(" ");
                Display(apps);
            }

            //var artAndDesignGroup = categoryGroup.First(g => g.Key == Category.ART_AND_DESIGN);

        }

        static void DataVerification(IEnumerable<GoogleApp> googleApps)
        {
            var allOperatorResult = googleApps.Where(a => a.Category == Category.WEATHER)
                .All(a => a.Reviews > 20);

            Console.WriteLine($"allOperatorResult: {allOperatorResult}");

            var anyOperatorResult = googleApps.Where(a => a.Category == Category.WEATHER)
                .Any(a => a.Reviews > 2_000_000);

            Console.WriteLine($"anyOperatorResult: {anyOperatorResult}");
        }

        static void DataSetOperation(IEnumerable<GoogleApp> googleApps)
        {
            // Distinct() - wyrzuca powtarzane elementy
            var paidAppsCategories = googleApps.Where(a => a.Type == Type.Paid)
                .Select(a => a.Category).Distinct();

            var setA = googleApps.Where(a => a.Rating > 4.7m && a.Type == Type.Paid && a.Reviews > 1000);
            var setB = googleApps.Where(a => a.Name.Contains("Pro") && a.Rating > 4.6m && a.Reviews > 10000);

            Display(setA);
            Console.WriteLine("");
            Console.WriteLine("******");
            Console.WriteLine("");
            Display(setB);
            Console.WriteLine("");
            Console.WriteLine("******");
            Console.WriteLine("Union: ");

            // Union() - łączy nam oba zbiory

            var unionOperator = setA.Union(setB);

            Display(unionOperator);
            Console.WriteLine("");
            Console.WriteLine("******");
            Console.WriteLine("Intersect: ");

            // Intersect - zwraca nam wspólną część dwoch zbiorów

            var intersectOperator = setA.Intersect(setB);

            Display(intersectOperator);
            Console.WriteLine("");
            Console.WriteLine("******");
            Console.WriteLine("Except: ");

            // Except() - zwraca nam zbior bez elementów drugiego zbioru

            var exceptOperator = setA.Except(setB);
            Display(exceptOperator);
            Console.WriteLine("");
            Console.WriteLine("******");
            Console.WriteLine("");

            //Console.WriteLine($"Paid apps categories: {string.Join(", ", paidAppsCategories)}");
        }

        static void OrderData(IEnumerable<GoogleApp> googleApps)
        {
            var highRatedBeautyApps = googleApps.Where(app => app.Rating > 4.4m && app.Category == Category.BEAUTY);
            var sortedByRating = highRatedBeautyApps.OrderByDescending(app => app.Rating)
                .ThenByDescending(app => app.Reviews)
                .Take(5);
            Display(sortedByRating);
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
            var highRatedApps = googleApps.Where(app => app.Rating > 4.6m);
            var highRatedBeautyApps = googleApps.Where(app => app.Rating > 4.6m && app.Category == Category.BEAUTY);
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

