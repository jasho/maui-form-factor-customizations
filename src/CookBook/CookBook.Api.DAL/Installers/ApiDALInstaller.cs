﻿using CookBook.Api.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Api.DAL.Installers
{
    public class ApiDALInstaller
    {
        public void Install(IServiceCollection services)
        {
            services.AddSingleton<IStorage, Storage>();
            services.AddSingleton<IIngredientRepository, IngredientRepository>();
            services.AddSingleton<IRecipeRepository, RecipeRepository>();
        }
    }
}
