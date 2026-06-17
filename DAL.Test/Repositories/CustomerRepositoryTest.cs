using Core.Models;
using DAL.Data;
using DAL.Repositories;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;

namespace DAL.Test.Repositories
{
    public class CustomerRepositoryTest
    {
        private readonly EducationContext _storeContext = A.Fake<EducationContext>();

        [Fact]
        public async Task GetCustomer_Success_Test()
        {
            var customerId = Guid.NewGuid();
            var fakeCustomer = new Student { Id = customerId, Name = "Customer" };

            _storeContext.Customers = A.Fake<DbSet<Student>>();

            A.CallTo(() => _storeContext.Customers.FindAsync(A<Guid>._))
                .Returns(new ValueTask<Student>(fakeCustomer));

            var customerRepository = new StudentRepository(_storeContext);
            var result = await customerRepository.GetAsync(customerId);

            Assert.NotNull(result);
            Assert.Equal(fakeCustomer.Id, result.Id);
            Assert.Equal(fakeCustomer.Name, result.Name);

            A.CallTo(() => _storeContext.Customers.FindAsync(customerId)).MustHaveHappenedOnceExactly();
        }
    }
}
