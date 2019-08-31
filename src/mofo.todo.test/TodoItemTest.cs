using mofo.todo.Core.Domain.Todos;
using NUnit.Framework;

namespace Tests
{
    public class TodoItemTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ItemValid()
        {
            var todoItem = new TodoItem("A", "Progress");

            var result = todoItem.IsValid();
            var expected = true;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ItemInvalid()
        {
            var todoItem = new TodoItem("A", "");

            var result = todoItem.IsValid();
            var expected = false;

            Assert.AreEqual(expected, result);
        }
    }
}