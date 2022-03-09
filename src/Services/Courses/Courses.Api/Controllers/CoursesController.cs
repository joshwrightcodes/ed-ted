using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Ted.Shared.Api.Controllers;
using Ted.Shared.Application.Exceptions;

namespace Ted.Services.Courses.Api.Controllers;

public partial class CoursesController : BaseApiController
{
    /// <summary>
    /// Defines route method names for the <see cref="CoursesController">courses controller</see>.
    /// </summary>
    public static partial class Routes
    {
        /// <summary>
        /// Defines route method names for v3 endpoints on the <see cref="CoursesController">courses controller</see>.
        /// </summary>
        public static partial class V3
        {
            /// <summary>
            /// Route method name for <see cref="CoursesController.GetCoursesAsync"/>.
            /// </summary>
            public const string GetCourses = "get-courses-v3";

            /// <summary>
            /// Route method name for <see cref="CoursesController.GetCourseAsync"/>
            /// </summary>
            public const string GetCourse = "get-course-v3";

            /// <summary>
            /// Route method name for <see cref="CoursesController.CreateCourseAsync"/>
            /// </summary>
            public const string CreateCourse = "create-course-v3";

            /// <summary>
            /// Route method name for <see cref="CoursesController.DeleteCourseAsync"/>
            /// </summary>
            public const string DeleteCourse = "delete-course-v3";

            /// <summary>
            /// Route method name for <see cref="CoursesController.UpdateCourseAsync"/>
            /// </summary>
            public const string UpdateCourse = "delete-course-v3";
        }
    }

    /// <summary>
    /// Retrieves a paginated list of <see cref="Course">courses</see> in Ted.
    /// </summary>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> to observe while waiting for the task to complete.
    /// </param>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet(Name = Routes.V3.GetCourses)]
    [ApiVersion("3.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status501NotImplemented)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public async Task GetCoursesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns information about the specified course in Ted.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> to observe while waiting for the task to complete.
    /// </param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpGet("{id:guid}", Name = Routes.V3.GetCourse)]
    [ApiVersion("3.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status501NotImplemented)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public async Task<IActionResult> GetCourseAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Creates a new course in Ted.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPost(Name = Routes.V3.CreateCourse)]
    [ApiVersion("3.0")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status501NotImplemented)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public async Task<IActionResult> CreateCourseAsync()
    {
        throw new ValidationException(new List<ValidationFailure>
        {
            new ValidationFailure("some property", "a validation error message"),
            new ValidationFailure("some property", "another validation error message"),
            new ValidationFailure("some property", "yet another validation error message"),
            new ValidationFailure("some other property", "a different validation error"),
        });
    }

    /// <summary>
    /// Removes the specified course from Ted.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpDelete("{id:guid}", Name = Routes.V3.DeleteCourse)]
    [ApiVersion("3.0")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status501NotImplemented)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public async Task<IActionResult> DeleteCourseAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates a specific course with the details provided in Ted.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [HttpPatch("{id:guid}", Name = Routes.V3.UpdateCourse)]
    [ApiVersion("3.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status501NotImplemented)]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
    public async Task<IActionResult> UpdateCourseAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}