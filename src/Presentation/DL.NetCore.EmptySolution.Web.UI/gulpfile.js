/// <binding BeforeBuild='build' />
const { series, parallel, src, dest } = require('gulp');
const concat = require('gulp-concat');
const terser = require('gulp-terser');
const cssmin = require('gulp-cssmin');
const rename = require('gulp-rename');
const del = require('del');

const bundleAndMinify = (srcFiles, destFileName, destPath, minifier) => {
    src(srcFiles)
        .pipe(concat(destFileName))
        .pipe(dest(destPath))
        .pipe(minifier())
        .pipe(rename({ suffix: '.min' }))
        .pipe(dest(destPath));
};

const clean = done => {
    del.sync(['wwwroot/**', '!wwwroot']);
    done();
};

const copyGlobalScripts = done => {
    bundleAndMinify(
        [
            'node_modules/jquery/dist/jquery.js',
            'node_modules/jquery-validation/dist/jquery.validate.js',
            'node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.js',
            'node_modules/popper.js/dist/umd/popper.js',
            'node_modules/bootstrap/dist/js/bootstrap.js'
        ],
        'global.js',
        'wwwroot/js',
        terser
    );

    done();
};

const copyGlobalStyles = done => {
    bundleAndMinify(
        [
            'assets/css/bootstrap-theme-default.css',
            'node_modules/@fortawesome/fontawesome-free/css/all.css'
        ],
        'global.css',
        'wwwroot/css',
        cssmin
    );

    done();
};

const copyFontawesomeFonts = done => {
    src([
        'node_modules/@fortawesome/fontawesome-free/webfonts/**.*'
    ])
        .pipe(dest('wwwroot/webfonts'));

    done();
};

const copyDatatablesScripts = done => {
    bundleAndMinify(
        [
            'node_modules/datatables.net/js/jquery.dataTables.js',
            'node_modules/datatables.net-bs4/js/dataTables.bootstrap4.js'
        ],
        'jquery.dataTables.js',
        'wwwroot/js',
        terser
    );

    done();
};

const copyDatatablesStyles = done => {
    bundleAndMinify(
        [
            'node_modules/datatables.net-bs4/css/dataTables.bootstrap4.css'
        ],
        'jquery.dataTables.css',
        'wwwroot/css',
        cssmin
    );

    done();
};

exports.clean = clean;
exports.build = series(
    clean,
    parallel(
        copyGlobalScripts,
        copyGlobalStyles,
        copyFontawesomeFonts,
        copyDatatablesScripts,
        copyDatatablesStyles
    )
);