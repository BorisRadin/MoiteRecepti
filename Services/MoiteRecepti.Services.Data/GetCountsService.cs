﻿using MoiteRecepti.Data.Common.Repositories;
using MoiteRecepti.Data.Models;
using MoiteRecepti.Services.Data.DTOs;
using MoiteRecepti.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoiteRecepti.Services.Data
{
    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IRepository<Image> imagesRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientsRepository;
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;

        public GetCountsService(
            IDeletableEntityRepository<Category> categoriesRepository,
            IRepository<Image> imagesRepository,
            IDeletableEntityRepository<Ingredient> ingredientsRepository,
            IDeletableEntityRepository<Recipe> recipesRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.imagesRepository = imagesRepository;
            this.ingredientsRepository = ingredientsRepository;
            this.recipesRepository = recipesRepository;
        }

        public CountsDTO GetCounts()
        {
            var viewmodel = new CountsDTO
            {
                CategoriesCount = this.categoriesRepository.All().Count(),
                ImagesCount = this.imagesRepository.All().Count(),
                IngredientsCount = this.ingredientsRepository.All().Count(),
                RecipesCount = this.recipesRepository.All().Count(),
            };
            return viewmodel;
        }
    }
}
