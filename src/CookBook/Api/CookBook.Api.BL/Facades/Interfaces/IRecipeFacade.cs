﻿using CookBook.Common.Models;

namespace CookBook.Api.BL.Facades.Interfaces;

public interface IRecipeFacade
{
    List<RecipeListModel> GetAll();
    RecipeDetailModel? GetById(Guid id);
    Guid Create(RecipeDetailModel recipeModel);
    Guid? Update(RecipeDetailModel recipeModel);
    void Delete(Guid id);
}