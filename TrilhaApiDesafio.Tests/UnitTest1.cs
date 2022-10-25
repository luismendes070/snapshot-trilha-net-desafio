using FakeItEasy;
using Xunit;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrilhaApiDesafio.Tests
{
    [TestClass]
    public class UnitTest1
    {

	[Fact]
	public async Task Get_API() 
	{

	// Arrange
	var client = new RestClient("http://localhost:3010/api/private");
	var request = new RestRequest(Method.GET);
	request.AddHeader("authorization", "Bearer YOUR_ACCESS_TOKEN");
	IRestResponse response = client.Execute(request);

	// Act

	// Assert

	Assert.Fail(true);
	}

        	[Fact]
			public async Task GetVendas_Returns_The_Correct_Number_Of_Vendas()
            {
				// Arrange
				int count = 5;
				var fakeVendas = A.CollectionOfDummy<Tarefa>(count).AsNumerable();
				var dataStore = A.Fake<ITarefaDataStore>();
				A.CallTo( () => dataStore.GetRandomVendas(count)).Returns(Task.FromResult(fakeVendas));
				var controller = new TarefaController(dataStore);
				// Act
				var actionResult = await controller.ObterPorId(count);

				// Assert
				var result = actionResult.Result as OkObjectResult;
				var returnVendas = result.Value as IEnumerable<Tarefa>;
				Assert.Equal(count, returnVendas.Count());
            }
    }
}
