using Entities;
using GD.Shared;
using GD.Shared.Metadata;
using GD.Shared.Metadata.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Bussines
{
    public class Project
    {
        private IProject ProjectRepositorio;

        public Project(IProject ProjectRepositorio)
        {
            this.ProjectRepositorio = ProjectRepositorio;
        }
        public int createProject(ProjectMetadata objProject)
        {
            Result result = new Result();

            int ResultS =  this.ProjectRepositorio.createProject(objProject);


            //if (ResultS > 0)
            //{
            //    result.HasErrors = false;
            //    result.Message = Messages.SuccessfullSave;
            //}
            //else
            //{
            //    result.HasErrors = true;
            //    result.Message = Messages.FailedAction;
            //}

            return 1;
        }

        public List<ProjectMetadata> ListProject(int page, int pageSize, string sort, string sortdir, ProjectMetadata ObjectProject)
        {
            return null;
        }
    }
}

