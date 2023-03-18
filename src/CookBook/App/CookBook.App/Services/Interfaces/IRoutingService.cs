﻿using CookBook.App.Components.Common.ViewModels;

namespace CookBook.App.Services;

public interface IRoutingService
{
    IEnumerable<RouteModel> Routes { get; }

    string GetRouteByViewModel<TViewModel>()
        where TViewModel : IViewModel;
}
