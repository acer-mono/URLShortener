const Encore = require('@symfony/webpack-encore');

if (!Encore.isRuntimeEnvironmentConfigured()) {
    Encore.configureRuntimeEnvironment(process.env.NODE_ENV || 'dev');
}

Encore
    .setPublicPath('/assets')
    .setOutputPath('wwwroot/assets')
    .enableReactPreset()
    .enableSassLoader()
    .addEntry('app', './assets/js/app.jsx')
    .addStyleEntry('styles', './assets/scss/app.scss')
    .disableSingleRuntimeChunk()
;

module.exports = Encore.getWebpackConfig();
