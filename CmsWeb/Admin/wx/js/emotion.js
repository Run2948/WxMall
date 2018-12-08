Emotion = {
    url: "/media/images/admin/emotion/",
    data: {
        0 : "微笑",
        1 : "撇嘴",
        2 : "色",
        3 : "发呆",
        4 : "得意",
        5 : "流泪",
        6 : "害羞",
        7 : "闭嘴",
        8 : "睡",
        9 : "大哭",
        10 : "尴尬",
        11 : "发怒",
        12 : "调皮",
        13 : "呲牙",
        14 : "惊讶",
        15 : "难过",
        16 : "酷",
        17 : "冷汗",
        18 : "抓狂",
        19 : "吐",
        20 : "偷笑",
        21 : "可爱",
        22 : "白眼",
        23 : "傲慢",
        24 : "饥饿",
        25 : "困",
        26 : "惊恐",
        27 : "流汗",
        28 : "憨笑",
        29 : "大兵",
        30 : "奋斗",
        31 : "咒骂",
        32 : "疑问",
        33 : "嘘",
        34 : "晕",
        35 : "折磨",
        36 : "衰",
        37 : "骷髅",
        38 : "敲打",
        39 : "再见",
        40 : "擦汗",
        41 : "抠鼻",
        42 : "鼓掌",
        43 : "糗大了",
        44 : "坏笑",
        45 : "左哼哼",
        46 : "右哼哼",
        47 : "哈欠",
        48 : "鄙视",
        49 : "委屈",
        50 : "快哭了",
        51 : "阴险",
        52 : "亲亲",
        53 : "吓",
        54 : "可怜",
        55 : "菜刀",
        56 : "西瓜",
        57 : "啤酒",
        58 : "篮球",
        59 : "乒乓",
        60 : "咖啡",
        61 : "饭",
        62 : "猪头",
        63 : "玫瑰",
        64 : "凋谢",
        65 : "示爱",
        66 : "爱心",
        67 : "心碎",
        68 : "蛋糕",
        69 : "闪电",
        70 : "炸弹",
        71 : "刀",
        72 : "足球",
        73 : "瓢虫",
        74 : "便便",
        75 : "月亮",
        76 : "太阳",
        77 : "礼物",
        78 : "拥抱",
        79 : "强",
        80 : "弱",
        81 : "握手",
        82 : "胜利",
        83 : "抱拳",
        84 : "勾引",
        85 : "拳头",
        86 : "差劲",
        87 : "爱你",
        88 : "NO",
        89 : "OK",
        90 : "爱情",
        91 : "飞吻",
        92 : "跳跳",
        93 : "发抖",
        94 : "怄火",
        95 : "转圈",
        96 : "磕头",
        97 : "回头",
        98 : "跳绳",
        99 : "挥手",
        100 : "激动",
        101 : "街舞",
        102 : "献吻",
        103 : "左太极",
        104 : "右太极"
    },
    ext: ".gif",
    replaceEmoji: function(f) {
        var b, h, d = Emotion,
        a = d.url,
        c = d.ext,
        g = d.data;
        for (b in g) {
            h = new RegExp("/" + g[b], "g"),
            f = f.replace(h, '<img src="' + a + b + c + '" alt="mo-' + g[b] + '"/>').replace(/\n/g, "<br />")
        }
        return f
    },
    replaceInput: function(a) {
        return a.replace(/<img.*?alt=["]{0,1}mo-([^"\s]*).*?>/ig, "/$1").replace(/<br.*?>/ig, "\n").replace(/<.*?>/g, "").replace(/&amp;/gi, "&").replace(/&quot;/gi, '"').replace(/&nbsp;/gi, " ").replace(/&copy;/gi, "©").replace(/&reg;/gi, "®")
    },
    getSelection: function() {
        return document.selection ? document.selection: window.getSelection()
    },
    getRange: function(c) {
        var d = Emotion;
        var a = d.getSelection();
        if (!a) {
            return null
        }
        var b = a.getRangeAt ? a.rangeCount ? a.getRangeAt(0) : null: a.createRange();
        return b ? c ? d.containsRange(c, b) ? b: null: b: null
    },
    contains: function(c, a, d) {
        if (!d && c === a) {
            return ! 1
        }
        if (c.compareDocumentPosition) {
            var b = c.compareDocumentPosition(a);
            if (b == 20 || b == 0) {
                return ! 0
            }
        } else {
            if (c.contains(a)) {
                return ! 0
            }
        }
        return ! 1
    },
    containsRange: function(c, a) {
        var d = Emotion;
        var b = a.commonAncestorContainer || a.parentElement && a.parentElement() || null;
        return b ? d.contains(c, b, !0) : !1
    },
    saveRange: function() {
        Emotion._lastRange = Emotion.getRange()
    },
    resotreRange: function() {
        var c = Emotion._lastRange;
        var b = Emotion;
        if (c) {
            var a = b.getSelection();
            if (a.addRange) {
                a.removeAllRanges(),
                a.addRange(c)
            } else {
                var d = b.getRange();
                d.setEndPoint("EndToEnd", c),
                d.setEndPoint("StartToStart", c),
                d.select()
            }
        }
        return this
    },
    focus: function(c) {
        $(".editArea div").focus();
        var b;
        if (c && (b = Emotion._lastRange)) {
            var d = Emotion.getSelection();
            if (d.addRange) {
                d.removeAllRanges();
                d.addRange(b)
            } else {
                var a = Emotion.getRange();
                a.setEndPoint("EndToEnd", b);
                a.setEndPoint("StartToStart", b);
                a.select()
            }
        }
        return Emotion.resotreRange()
    },
    insertHTML: function(d) {
        Emotion.focus(1);
        var b = Emotion.getRange();
        if (b.createContextualFragment) {
            d += '<img style="width:1px;height:1px;">';
            var f = b.createContextualFragment(d),
            a = f.lastChild;
            b.deleteContents(),
            b.insertNode(f),
            b.setEndAfter(a),
            b.setStartAfter(a);
            var c = Emotion.getSelection();
            c.removeAllRanges(),
            c.addRange(b),
            document.execCommand("Delete", !1, null)
        } else {
            b.pasteHTML(d);
            b.collapse(!1);
            b.select()
        }
        Emotion.saveRange();
        return this
    }
};