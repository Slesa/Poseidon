﻿using System.Collections.ObjectModel;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.BackOffice.Module.Ics.ViewModels
{
    public class RecipesViewModel
    {
        public ObservableCollection<Recipe> Recipes { get; set; }         
    }
}