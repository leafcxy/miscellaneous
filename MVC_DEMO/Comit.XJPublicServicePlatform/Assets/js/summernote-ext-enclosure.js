(function (factory) {
    /* global define */
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define(['jquery'], factory);
    } else {
        // Browser globals: jQuery
        factory(window.jQuery);
    }
}(function ($) {
    // template
    var tmpl = $.summernote.renderer.getTemplate();

    // core functions: range, dom
    var range = $.summernote.core.range;
    var dom = $.summernote.core.dom;

    /**
     * createVideoNode
     *  生成节点
     * @member plugin.video
     * @private
     * @param {String} url
     * @return {Node}
     */
    var createVideoNode = function (url,enclosurename) {
        
        var $enclosure;
        $enclosure = $('<a>')
        .attr('href', url)
        .attr('text', enclosurename);

        return $enclosure[0];
    };

    /**
     * @member plugin.video
     * @private
     * @param {jQuery} $editable
     * @return {String}
     */
    var getEnclosurenameOnRange = function ($editable) {
        $editable.focus();

        var rng = range.create();

        // if range on anchor, expand range with anchor
        if (rng.isOnAnchor()) {
            var anchor = dom.ancestor(rng.sc, dom.isAnchor);
            rng = range.createFromNode(anchor);
        }

        return rng.toString();
    };

    /**
     * toggle button status
     *  按钮是否可用
     * @member plugin.video
     * @private
     * @param {jQuery} $btn
     * @param {Boolean} isEnable
     */
    var toggleBtn = function ($btn, isEnable) {
        $btn.toggleClass('disabled', !isEnable);
        $btn.attr('disabled', !isEnable);
    };

    /**
     * Show video dialog and set event handlers on dialog controls.
     *打开对话框，并绑定事件处理程序
     * @member plugin.video
     * @private
     * @param {jQuery} $dialog
     * @param {jQuery} $dialog
     * @param {Object} text
     * @return {Promise}
     */
    var showVideoDialog = function ($editable, $dialog, text,editor, layoutInfo) {
        return $.Deferred(function (deferred) {
            var $videoDialog = $dialog.find('.note-video-dialog');

            var $videoUrl = $videoDialog.find('.note-video-url'),
                $videoBtn = $videoDialog.find('.note-video-btn');
                $enclosure = $videoDialog.find('.note-enclosure-input');
            

            $videoDialog.one('shown.bs.modal', function () {
                $videoUrl.val(text).on('input', function () {
                    toggleBtn($videoBtn, $videoUrl.val());
                    
                }).trigger('focus');


                $enclosure.replaceWith($enclosure.clone()
                .on('change', function () {
                    //alert("skfah");
                    //sendFile(this.files[0], editor, $editable, "enclosure", $videoUrl.val());
                    deferred.resolve(this.files[0], editor, $editable, $videoUrl.val());
                    $videoDialog.modal('hide');
                })
                .val('')
                );

                $videoBtn.click(function (event) {
                    event.preventDefault();//取消事件的默认动作

                    //$enclosure.click();
                    //$enclosure.val("");
                    $videoDialog.modal('hide');
                });
            }).one('hidden.bs.modal', function () {
                $videoUrl.off('input');
                $videoBtn.off('click');
                if (deferred.state() === 'pending') {
                    deferred.reject();//状态改为结束
                }
            }).modal('show');
        });
    };

    /**
     * @class plugin.video
     *
     * Video Plugin
     *
     * video plugin is to make embeded video tag.
     *
     * ### load script
     *
     * ```
     * < script src="plugin/summernote-ext-video.js"></script >
     * ```
     *
     * ### use a plugin in toolbar
     * ```
     *    $("#editor").summernote({
     *    ...
     *    toolbar : [
     *        ['group', [ 'video' ]]
     *    ]
     *    ...    
     *    });
     * ```
     */
    $.summernote.addPlugin({
        /** @property {String} name name of plugin */
        name: 'enclosure',
        /**
         * @property {Object} buttons
         * @property {function(object): string} buttons.video
         */
        buttons: {
            enclosure: function (lang) {
                return tmpl.iconButton('fa icon-upload-alt', {
                    event: 'showVideoDialog',
                    title: lang.enclosure.video,
                    hide: true
                });
            }
        },

        /**
         * @property {Object} dialogs
         * @property {function(object, object): string} dialogs.video
        */
        dialogs: {
            enclosure: function (lang) {
                var body = '<div class="form-group row-fluid">' +
                             '<label>' + lang.enclosure.url + ' <small class="text-muted">' + lang.enclosure.providers + '</small></label>' +
                             '<input class="note-video-url form-control span12" type="text" />' +
                             '<label><small class="text-danger">' + lang.enclosure.tip + '</small></label>' +
                             '<br /><input class="note-enclosure-input" type="file" name="files" id="uploadenclosure" />' +
                           '</div>';
                var footer = '<button href="#" class="btn btn-primary note-video-btn disabled" disabled>' + lang.enclosure.insert + '</button>';
                return tmpl.dialog('note-video-dialog', lang.enclosure.insert, body, footer);
            }
        },
        /**
         * @property {Object} events
         * @property {Function} events.showVideoDialog
         */
        events: {
            showVideoDialog: function (event, editor, layoutInfo) {
                var $dialog = layoutInfo.dialog(),
                    $editable = layoutInfo.editable(),
                    text = getEnclosurenameOnRange($editable);

                // save current range
                editor.saveRange($editable);

                showVideoDialog($editable, $dialog, text, editor, layoutInfo).then(function (files, editor, $editable, filename) {
                    // when ok button clicked 点击确定
                    // restore range
                    editor.restoreRange($editable);
                    //alert("990");
                    sendFile(files, editor, $editable, "enclosure", filename);


                }).fail(function () {
                    // when cancel button clicked 点击取消
                    editor.restoreRange($editable);
                });
            }
        },

        // define language，定义语言
        langs: {
            'en-US': {
                enclosure: {
                    video: 'Video',
                    videoLink: 'Video Link',
                    insert: 'Insert Video',
                    url: 'Video URL?',
                    providers: '(YouTube, Vimeo, Vine, Instagram, DailyMotion or Youku)',
                    tip:'fill enclosure name before selected'
                }
            },
            'zh-CN': {
                enclosure: {
                    video: '附件',
                    videoLink: '附件名称',
                    insert: '插入附件',
                    url: '附件名',
                    providers: '(附件大小不能大于4M)',
                    tip:'先填写附件名再选择附件'
                }
            }
        }

    });
}));
