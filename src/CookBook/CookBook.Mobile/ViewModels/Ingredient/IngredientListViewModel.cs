﻿using CookBook.Common.Models;
using CookBook.Mobile.Api;
using CookBook.Mobile.Services;
using Microsoft.Toolkit.Mvvm.Input;

namespace CookBook.Mobile.ViewModels;

public partial class IngredientListViewModel : ViewModelBase
{
    private readonly IRoutingService routingService;
    private readonly IIngredientsClient ingredientsClient;

    public ICollection<IngredientListModel>? Items { get; set; }

    public IngredientListViewModel(
        IRoutingService routingService,
        IIngredientsClient ingredientsClient)
    {
        this.routingService = routingService;
        this.ingredientsClient = ingredientsClient;
    }

    public override async Task OnAppearingAsync()
    {
        await base.OnAppearingAsync();

        Items = await ingredientsClient.GetIngredientsAllAsync();
    }

    [ICommand]
    private async Task GoToDetailAsync(Guid id)
    {
        var route = routingService.GetRouteByViewModel<IngredientDetailViewModel>();
        await Shell.Current.GoToAsync($"{route}?id={id}");
    }

    [ICommand]
    private async Task GoToCreateAsync()
    {
        var route = routingService.GetRouteByViewModel<IngredientEditViewModel>();
        await Shell.Current.GoToAsync(route);
    }

    [ICommand]
    private async Task GoToEditAsync(Guid id)
    {
        var route = routingService.GetRouteByViewModel<IngredientEditViewModel>();
        await Shell.Current.GoToAsync($"{route}?id={id}");
    }
}
