using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.DataAccess.Concrete.EntityFramework
{
    public class EfStudentDal : EfEntityRepositoryBase<Product, NortwindContext>, IProductDal
    {

    }
}
