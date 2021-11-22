using M223PunchclockBlazor.Poco.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M223PunchclockBlazor.Services.ProjectService
{
    interface IProjectService
    {
        public Task<bool> AddProjectAsync(PostProject user);
        public Task<List<Project>> GetProjectsAsync();
        public Task<Project> GetProjectAsync(int? id);
        public Task<bool> UpdateProjectAsync(Project user);
        public Task<bool> DeleteProjectAsync(int? id);
    }
}
