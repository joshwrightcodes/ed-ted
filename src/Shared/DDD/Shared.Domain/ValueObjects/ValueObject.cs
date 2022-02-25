namespace Ted.Shared.Domain.ValueObjects;

/// <summary>
/// Represents a simple entity whose equality is based on its value not its identity.
/// </summary>
public abstract class ValueObject
{
    /// <summary>
    /// Compares two <see cref="ValueObject">value objects</see> for equality.
    /// </summary>
    /// <param name="left">Left <see cref="ValueObject">value object</see> to compare.</param>
    /// <param name="right">Right <see cref="ValueObject">value object</see> to compare.</param>
    /// <returns>
    /// <c>true</c> if <see cref="ValueObject">value objects</see> are equal, otherwise returns <c>false</c>.
    /// </returns>
    protected static bool EqualOperator(ValueObject left, ValueObject right)
    {
        if (left is null ^ right is null) return false;

        return left?.Equals(right!) != false;
    }

    /// <summary>
    /// Compares two <see cref="ValueObject">value objects</see> for inequality.
    /// </summary>
    /// <param name="left">Left <see cref="ValueObject">value object</see> to compare.</param>
    /// <param name="right">Right <see cref="ValueObject">value object</see> to compare.</param>
    /// <returns>
    /// <c>false</c> if <see cref="ValueObject">value objects</see> are equal, otherwise returns <c>true</c>.
    /// </returns>
    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
        return !EqualOperator(left, right);
    }

    /// <summary>
    /// Gets the components of a given <see cref="ValueObject">value object</see> to use for equality comparision.
    /// </summary>
    /// <returns>
    /// A collection of properties within an <see cref="ValueObject">value object</see> to use for equality comparison.
    /// </returns>
    protected abstract IEnumerable<object> GetEqualityComponents();

    /// <summary>
    /// Returns a value that indicates whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="obj">The object to compare with this instance.</param>
    /// <returns>
    /// <c>true</c> if <paramref name="obj" /> is a <see cref="ValueObject">value object</see> that has the same value
    /// as this instance; otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType()) return false;

        var other = (ValueObject) obj;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    /// <summary>
    /// Returns a hash code for the provided <see cref="ValueObject">value object</see>.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }
}