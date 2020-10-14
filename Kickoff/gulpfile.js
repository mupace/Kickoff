var gulp = require("gulp");
var sass = require("gulp-sass");
var uglify = require("gulp-uglify");

gulp.task('sass', function () {
    return gulp.src('Content/css/scss/*.scss')
        .pipe(sass())
        .pipe(gulp.dest('Content/css'))
});

gulp.task('uglify', function () {
    return gulp.src('Scripts/stylish-portfolio.js')
        .pipe(uglify())
        .gulp.dest('Scripts/stylish-portfolio.min.js')
});