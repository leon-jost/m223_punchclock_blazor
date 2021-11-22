using M223PunchclockBlazor.Poco.Project;
using M223PunchclockBlazor.Services.ProjectService;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Pages
{
    public partial class ManageProjects
    {
        [Inject]
        private IProjectService ProjectService { get; set; }

        private List<Project> _projects;

        private PostProject _newProject = new();

        protected async override Task OnInitializedAsync()
        {
            _projects = await ProjectService.GetProjectsAsync();
        }

        public async Task DeleteProjectAsync(Project user)
        {
            await ProjectService.DeleteProjectAsync(user.id);
            _projects = await ProjectService.GetProjectsAsync();
        }

        public async Task AddProjectAsync(PostProject user)
        {
            await ProjectService.AddProjectAsync(user);
            _projects = await ProjectService.GetProjectsAsync();
        }
    }
}