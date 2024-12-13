using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System.Linq.Expressions;

namespace MSMS.Tests.Extensions
{
    public static class DbSetMockingExtensions
    {
        public static Mock<DbSet<T>> BuildMockDbSet<T>(this IQueryable<T> source) where T : class
        {
            var mockDbSet = new Mock<DbSet<T>>();

            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(source.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(source.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(source.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(source.GetEnumerator());

            mockDbSet.Setup(m => m.AddAsync(It.IsAny<T>(), default))
                     .Callback<T, CancellationToken>((entity, _) => ((List<T>)source).Add(entity));
            //mockDbSet.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<T, bool>>>(), default))
            //    .Returns((Expression<Func<T, bool>> predicate, CancellationToken _) => source.FirstOrDefault(predicate.Compile()));

            return mockDbSet;
        }
    }
}
