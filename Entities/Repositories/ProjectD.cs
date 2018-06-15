using GD.Model;
using GD.Shared.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Data.Entity;



namespace Entities.Repositories
{
    public class ProjectD : IProject
    {

        private Project ConvertM(ProjectMetadata objProjectMetada)
        {

            Project ObjectProject = new Project();

            ObjectProject.CodProject = objProjectMetada.CodProject;
            ObjectProject.NameProject = objProjectMetada.NameProject;
            ObjectProject.IdRepresent = objProjectMetada.IdRepresent;
            ObjectProject.DateCreate = objProjectMetada.DateCreate;
            ObjectProject.UseProject = objProjectMetada.UseProject;
            ObjectProject.Active = objProjectMetada.Active;
            ObjectProject.Avance = objProjectMetada.Avance;

            return ObjectProject;
        }
        public int createProject(ProjectMetadata objProject)
        {
            try
            {
                Project objProjectEnt = new Project();
                int result = 0;
                using (GDEntities db = new GDEntities())
                {
                    objProjectEnt = ConvertM(objProject);
                    using (var context = db.Database.BeginTransaction())
                    {
                        db.Project.Add(objProjectEnt);
                        db.SaveChanges();
                        context.Commit();
                        result = objProjectEnt.IdProject;
                    }
                }
                return 1;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ProjectMetadata EditProject(ProjectMetadata objProject)
        {
            return null;
        }
        public ProjectMetadata GetProject(int idProject)
        {
            return null;
        }
        public List<Project> getListProject(int page, int pageSize, string sort, string sortdir, ProjectMetadata ObjectProject)
        {

            using (GDEntities db = new GDEntities())
            {
                var listProject = (from p in db.Project
                                        where (p.IdProject > 0 ? p.IdProject == ObjectProject.IdProject :p.IdProject> 0) &&
                                        (p.NameProject == null ? p.NameProject == ObjectProject.NameProject: p.NameProject == null)
                                        select p).ToList();

                int totalRows = listProject.Count();

                if (totalRows > 0)
                {
                    listProject = listProject.OrderBy(sort + " " + sortdir).Skip(page).Take(pageSize).ToList();
                }
                return listProject;
            }
        }

    }
}
}
