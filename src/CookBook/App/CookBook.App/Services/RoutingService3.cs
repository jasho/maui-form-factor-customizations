﻿using CookBook.App.Components.Common.Models;
using CookBook.App.Components.Common.Services;
using CookBook.App.Components.Common.ViewModels;
using CookBook.App.Components.Views;
using CookBook.App.Views;

namespace CookBook.App.Services;

public class RoutingService3 : IRoutingService
{
    private static ICollection<RouteModel> routesCommon = new List<RouteModel>
    {
        new("//recipes", typeof(RecipeListView), typeof(RecipeListViewModel)),
        new("//ingredients", typeof(IngredientListView), typeof(IngredientListViewModel)),
        new("//settings", typeof(SettingsView), typeof(SettingsViewModel)),

        new("//ingredients/edit", typeof(IngredientEditView), typeof(IngredientEditViewModel)),

        new("//ingredients/detail", typeof(IngredientDetailView), typeof(IngredientDetailViewModel)),
        new("//ingredients/detail/edit", typeof(IngredientEditView), typeof(IngredientEditViewModel)),

        new("//recipes/detail", typeof(RecipeDetailView), typeof(RecipeDetailViewModel)),
        new("//recipes/detail/edit", typeof(RecipeEditView), typeof(RecipeEditViewModel)),

        new("//recipes/edit", typeof(RecipeEditView), typeof(RecipeEditViewModel)),
    };

    private static IEnumerable<RouteModel> routesPhone = new List<RouteModel>
    {
    }.Concat(routesCommon);

    private static IEnumerable<RouteModel> routesDesktop = new List<RouteModel>
    {
        new("//recipes/detail/edit/ingredients", typeof(RecipeIngredientsEditViewDesktop), typeof(RecipeIngredientsEditViewModel)),
        new("//recipes/edit/ingredients", typeof(RecipeIngredientsEditViewDesktop), typeof(RecipeIngredientsEditViewModel)),
    }.Concat(routesCommon);

    public IEnumerable<RouteModel> Routes
        => routesCommon
#if PHONE
            .Concat(new List<RouteModel>());
#elif DESKTOP
            .Concat(new List<RouteModel>
            {
                new("//recipes/detail/edit/ingredients", typeof(RecipeIngredientsEditViewDesktop), typeof(RecipeIngredientsEditViewModel)),
                new("//recipes/edit/ingredients", typeof(RecipeIngredientsEditViewDesktop), typeof(RecipeIngredientsEditViewModel)),
            });
#endif

    public string GetRouteByViewModel<TViewModel>()
        where TViewModel : IViewModel
        => Routes.First(route => route.ViewModelType == typeof(TViewModel)).Route;
}