using Entities.Repositories;
using GD.Model;
using GD.Shared.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IProject
    {
        int createProject(ProjectMetadata objProject);
        ProjectMetadata EditProject(ProjectMetadata objProject);

        ProjectMetadata GetProject(int idProject);

        List<Project> getListProject(int page, int pageSize, string sort, string sortdir, ProjectMetadata ObjectProject);
    }
    
}
