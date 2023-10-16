using System.Collections;

namespace Lab1.SortedList.Tests;
using FluentAssertions;

public class SortedListTests
{
    [Fact]
    public void Add_AddsItemToSortedList()
    {
        // Arrange
        var sortedList = new SortedList<int>();

        // Act
        sortedList.Add(3);
        sortedList.Add(1);
        sortedList.Add(2);

        // Assert
        sortedList.Should().BeInAscendingOrder();
        sortedList.Should().HaveCount(3);
        sortedList.Should().ContainInOrder(1, 2, 3);
    }
    
    [Fact]
    public void AddNull_ThrowsArgumentNullException()
    {
        // Arrange
        var sortedList = new SortedList<string>();

        // Act
        var addAction = () => sortedList.Add(null!);

        // Assert
        addAction.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Remove_RemovesItemFromSortedList()
    {
        // Arrange
        var sortedList = new SortedList<string>();
        sortedList.Add("a");
        sortedList.Add("b");
        sortedList.Add("c");
        sortedList.Add("d");

        // Act
        var result = sortedList.Remove("c");

        // Assert
        result.Should().BeTrue();
        sortedList.Should().HaveCount(3);
        sortedList.Should().ContainInOrder("a", "b", "d");
    }
    
    [Fact]
    public void Remove_ReturnsFalseIfNoItems()
    {
        // Arrange
        var sortedList = new SortedList<string>();

        // Act
        var result = sortedList.Remove("d");

        // Assert
        result.Should().BeFalse();
        sortedList.Should().HaveCount(0);
    }
    
    [Fact]
    public void Remove_ReturnsFalseIfItemsIsNotInList()
    {
        // Arrange
        var sortedList = new SortedList<string>();
        sortedList.Add("a");

        // Act
        var result = sortedList.Remove("d");

        // Assert
        result.Should().BeFalse();
        sortedList.Should().HaveCount(1);
    }
    
    [Fact]
    public void Remove_ReturnsTrueIfItemIsInHead()
    {
        // Arrange
        var sortedList = new SortedList<string>();
        sortedList.Add("a");

        // Act
        var result = sortedList.Remove("a");

        // Assert
        result.Should().BeTrue();
        sortedList.Should().HaveCount(0);
    }
    
    [Fact]
    public void RemoveNull_ThrowsArgumentNullException()
    {
        // Arrange
        var sortedList = new SortedList<string>();
        sortedList.Add("a");
        sortedList.Add("b");
        sortedList.Add("c");

        // Act
        var removeAction = () => sortedList.Remove(null!);

        // Assert
        removeAction.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Find_ReturnsItemMatchingPredicate()
    {
        // Arrange
        var sortedList = new SortedList<int>();
        sortedList.Add(1);
        sortedList.Add(2);
        sortedList.Add(3);

        // Act
        var result = sortedList.Find(x => x == 2);

        // Assert
        result.Should().Be(2);
    }
    
    [Fact]
    public void Find_ReturnsNullIfNoItemMatchesPredicate()
    {
        // Arrange
        var sortedList = new SortedList<string>();
        sortedList.Add("a");
        sortedList.Add("b");
        sortedList.Add("c");

        // Act
        var result = sortedList.Find(x => x == "e");

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public void Clear_RemovesAllItemsFromSortedList()
    {
        // Arrange
        var sortedList = new SortedList<int>();
        sortedList.Add(1);
        sortedList.Add(2);
        sortedList.Add(3);

        // Act
        sortedList.Clear();

        // Assert
        sortedList.Should().BeEmpty();
    }
    
    [Fact]
    public void Contains_ReturnsTrueIfItemExists()
    {
        // Arrange
        var sortedList = new SortedList<string>();
        sortedList.Add("apple");
        sortedList.Add("banana");
        sortedList.Add("cherry");

        // Act
        var contains = sortedList.Contains("banana");
        
        // Assert
        contains.Should().BeTrue();
    }

    [Fact]
    public void Contains_ReturnsFalseIfItemDoesNotExist()
    {
        // Arrange
        var sortedList = new SortedList<int>();
        sortedList.Add(1);
        sortedList.Add(3);
        sortedList.Add(5);

        // Act
        var contains = sortedList.Contains(2);
        
        // Assert
        contains.Should().BeFalse();
    }

    [Fact]
    public void CopyTo_CopiesItemsToDestinationArray()
    {
        // Arrange
        var sortedList = new SortedList<int>();
        sortedList.Add(1);
        sortedList.Add(2);
        sortedList.Add(3);
        var destinationArray = new int[3];

        // Act
        sortedList.CopyTo(destinationArray, 0);

        // Assert
        destinationArray.Should().ContainInOrder(1, 2, 3);
    }
    
    [Fact]
    public void CopyTo_ThrowsArgumentNullExceptionIfArrayIndexIsNegative()
    {
        // Arrange
        var sortedList = new SortedList<int>();
        sortedList.Add(1);
        sortedList.Add(2);
        sortedList.Add(3);
        var destinationArray = new int[3];

        // Act
        var copyAction = () => sortedList.CopyTo(destinationArray, -1);
        
        // Assert
        copyAction.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void CopyTo_ThrowsArgumentExceptionIfDestinationArrayIsTooShort()
    {
        // Arrange
        var sortedList = new SortedList<int>();
        sortedList.Add(1);
        sortedList.Add(2);
        var destinationArray = new int[1];

        // Act
        var copyAction = () => sortedList.CopyTo(destinationArray, 0);
        
        // Assert
        copyAction.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void SubscribeOnAdd_InvokesEventHandlerWhenItemIsAdded()
    {
        // Arrange
        var sortedList = new SortedList<int>();
        var eventWasInvoked = false;
        sortedList.OnAdd += (_, _) => eventWasInvoked = true;

        // Act
        sortedList.Add(1);

        // Assert
        eventWasInvoked.Should().BeTrue();
    }
    
    [Fact]
    public void SubscribeOnRemove_InvokesEventHandlerWhenItemIsRemoved()
    {
        // Arrange
        var sortedList = new SortedList<int>();
        var eventWasInvoked = false;
        sortedList.OnRemove += (_, _) => eventWasInvoked = true;
        sortedList.Add(1);

        // Act
        sortedList.Remove(1);

        // Assert
        eventWasInvoked.Should().BeTrue();
    }
    
    [Fact]
    public void SubscribeOnClear_InvokesEventHandlerWhenListIsCleared()
    {
        // Arrange
        var sortedList = new SortedList<int>();
        var eventWasInvoked = false;
        sortedList.OnClear += (_, _) => eventWasInvoked = true;
        sortedList.Add(1);

        // Act
        sortedList.Clear();

        // Assert
        eventWasInvoked.Should().BeTrue();
    }
    
    [Fact]
    public void GetEnumerator_ReturnsEnumerator()
    {
        // Arrange
        var sortedList = new SortedList<int>();
        sortedList.Add(1);
        sortedList.Add(2);

        // Act
        using var enumerator = sortedList.GetEnumerator();

        // Assert
        enumerator.Should().NotBeNull();
        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(1);
        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(2);
        enumerator.MoveNext().Should().BeFalse();
    }
    
    [Fact]
    public void IEnumerableGetEnumerator_ReturnsEnumerator()
    {
        // Arrange
        var sortedList = new SortedList<int>();
        sortedList.Add(1);
        sortedList.Add(2);

        // Act
        var enumerator = ((IEnumerable) sortedList).GetEnumerator();

        // Assert
        enumerator.Should().NotBeNull();
        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(1);
        enumerator.MoveNext().Should().BeTrue();
        enumerator.Current.Should().Be(2);
        enumerator.MoveNext().Should().BeFalse();
    }
}