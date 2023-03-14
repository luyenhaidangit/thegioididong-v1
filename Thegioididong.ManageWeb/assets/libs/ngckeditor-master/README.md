CKEditor + AngularJS
====================

Code licensed under New BSD License.

## Installing via Bower
```
bower install ngckeditor
```

##Usage
```html
<textarea ckeditor="editorOptions" ng-model="modelName"></textarea>
```

```js
// add dependency
angular.module('app', ['ngCkeditor'])

// setup editor options
$scope.editorOptions = {
    language: 'ru',
    uiColor: '#000000'
};
```
