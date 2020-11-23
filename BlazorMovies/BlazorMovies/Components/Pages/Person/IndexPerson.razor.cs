﻿using BlazorMovies.Shared.DataTransferObjects;
using BlazorMovies.Shared.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorMovies.Components.Pages.Person
{
    [Authorize(Roles = "Admin")]
    public partial class IndexPerson
    {
        private List<BlazorMovies.Shared.Entities.Person> PersonList;
        private PaginationDTO pagination = new PaginationDTO() { RecordsPerPage = 4 };
        private int totalAmountOfPages;

        [Inject]
        protected IPersonRepository personRepository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await LoadPeople();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        private async Task DeletePerson(int id)
        {
            await personRepository.DeletePerson(id);
            await LoadPeople();
        }

        private async Task LoadPeople()
        {
            var paginatedResponse = await personRepository.GetPersons(pagination);
            PersonList = paginatedResponse.Response;
            totalAmountOfPages = paginatedResponse.TotalAmountOfPages;
        }

        private async Task SelectedPage(int page)
        {
            pagination.Page = page;
            await LoadPeople();
        }
    }
}