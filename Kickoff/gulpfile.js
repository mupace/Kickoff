var gulp = require("gulp");
var sass = require("gulp-sass");
var cleanCSS = require("gulp-clean-css");
var concat = require("gulp-concat");
var uglify = require("gulp-uglify");

gulp.task('sass', function () {
    gulp.src('Content/css/scss/*.scss')
        .pipe(sass())
        .pipe(gulp.dest('Content/css/'));

    return gulp.src('Content/css/scss/*.scss')
        .pipe(sass())
        .pipe(cleanCSS())
        .pipe(concat('stylish-portfolio.min.css'))
        .pipe(gulp.dest('Content/css/'));
});

gulp.task('uglify', function () {
    return gulp.src('Scripts/stylish-portfolio.js')
        .pipe(uglify())
        .pipe(concat('stylish-portfolio.min.js'))
        .pipe(gulp.dest('Scripts/'));
});

//gulp.task('watch', function () {
//    gulp.watch('Content/css/scss/*.scss', ['sass']);

//    gulp.watch('Scripts/stylish-portfolio.js', ['uglify']);
//})

gulp.task('watch', function () {
    gulp.watch('Content/css/scss/*.scss', gulp.series('sass'));
    gulp.watch('Scripts/stylish-portfolio.js', gulp.series('uglify'));
    return;
})