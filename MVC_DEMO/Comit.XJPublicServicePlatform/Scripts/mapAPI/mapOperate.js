!
function() {
    var flashPath = "/Scripts/mapAPI/shipxyAPI.swf?t=112";
	var flash = null;
	var toObject = function(e) {
			if (e == null || !(e instanceof Object)) {
				return null
			}
			var t = {},
				a;
			for (var i in e) {
				a = e[i];
				if (!(a instanceof Function)) {
					if (a instanceof Array) {
						var r = [],
							s;
						for (var n = 0, o = a.length; n < o; n++) {
							s = a[n];
							if (s instanceof Object) {
								r[n] = toObject(s)
							} else {
								r[n] = s
							}
						}
						t[i] = r
					} else if (a instanceof Object) {
						t[i] = toObject(a)
					} else {
						t[i] = a
					}
				}
			}
			return t
		};
	var inheritPrototype = function(e, t, a) {
			function i() {}
			i.prototype = t.prototype;
			var r = new i;
			r.constructor = e;
			if (a) {
				for (var s in a) {
					if (a.hasOwnProperty(s)) r[s] = a[s]
				}
			}
			e.prototype = r
		};
	var throwFlashError = function(e, t) {
			var a = "调用flash方法" + e + "出错，";
			if (!flash || !flash[e]) {
				a += "flash未初始化完成，未找到" + e + "方法"
			} else {
				a += t
			}
			throw new Error(a)
		};
	var getFlashObject = function(e, t, a) {
			var i;
			var r = /MSIE/.test(navigator.userAgent);
			if (r) {
				try {
					new ActiveXObject("ShockwaveFlash.ShockwaveFlash")
				} catch (s) {
					i = true
				}
			} else {
				if (!(navigator.mimeTypes && navigator.mimeTypes["application/x-shockwave-flash"])) {
					i = true
				}
			}
			if (i) {
				t.innerHTML = "Flash未安装";
				return
			}
			if (getFlashVer() < 9) {
				var n = "Alternate HTML content should be placed here. " + "This content requires the Adobe Flash Player. " + '<a href="http://www.adobe.com/go/getflash/">Get Flash</a>';
				t.innerHTML = n;
				return
			}
			var o = '<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" id="' + e + '" name="' + e + '"' + ' width="100%" height="100%" codebase="http://fpdownload.macromedia.com/get/flashplayer/current/swflash.cab">' + '<param name="quality" value="high" />' + '<param name="bgcolor" value="#869ca7" />' + '<param name="allowScriptAccess" value="always" />' + '<param name="allowFullScreen" value="true" />' + '<param name="wmode" value="transparent" />' + '<param name="SRC" value="' + flashPath + '" />' + '<param name="FlashVars" value="mapId=' + e + "&key=" + shipxyMap.key + "&center=" + a.center.lat + "," + a.center.lng + "&zoom=" + a.zoom + "&mapType=" + a.mapType + "&mapTypes=" + a.mapTypes + '"/>' + '<embed src="' + flashPath + '" wmode="transparent" quality="high" bgcolor="#869ca7"' + ' width="100%" height="100%" id="' + e + '" name="' + e + '" align="middle" play="true" loop="false"' + ' allowscriptaccess="always"  allowFullScreen="true"  type="application/x-shockwave-flash" ' + ' FlashVars="mapId=' + e + "&key=" + shipxyMap.key + "&center=" + a.center.lat + "," + a.center.lng + "&zoom=" + a.zoom + "&mapType=" + a.mapType + "&mapTypes=" + a.mapTypes + '"></embed></object>';
			t.innerHTML = o;
			return r ? t.childNodes[0] : t.getElementsByTagName("embed")[0]
		};
	var getFlashVer = function() {
			var f = "";
			var n = navigator;
			if (n.plugins && n.plugins.length) {
				for (var i = 0; i < n.plugins.length; i++) {
					if (n.plugins[i].name.indexOf("Shockwave Flash") != -1) {
						f = n.plugins[i].description.split("Shockwave Flash")[1].split(" ")[1];
						break
					}
				}
			} else if (window.ActiveXObject) {
				for (var j = 10; j >= 2; j--) {
					try {
						var f1 = eval("new ActiveXObject('ShockwaveFlash.ShockwaveFlash." + j + "');");
						if (f1) {
							f = j + ".0";
							break
						}
					} catch (e) {}
				}
			}
			return f
		};
	var jsCallbackHook = {};
	var jsEventHook = {};
	var overlayList = {};
	shipxyMap = {
		name: "shipxyMap",
		key: "1F6D701272402D1E7D8D316CCE519123",
		Map: function(e, t) {
			if (this instanceof shipxyMap.Map) {
				var a = null;
				if (typeof e === "object") {
					a = e
				} else if (typeof e === "string") {
					a = document.getElementById(e)
				} else {
					throw new Error("请为shipxyMap.Map构造函数指定第一个参数，该参数是装载地图的HTML容器，可以是容器本身，也可以是其id属性")
				}
				if (!a) {
					a.innerHTML = "未能找到flash容器";
					return
				}
				t = t || new shipxyMap.MapOptions;
				if (!(t instanceof shipxyMap.MapOptions)) {
					throw new Error("请为shipxyMap.Map构造函数第二个参数指定为shipxyMap.MapOptions的一个实例，或者为空值采用默认内容")
				}
				this.center = t.center;
				this.zoom = t.zoom;
				this.mapType = t.mapType;
				this.id = "map" + (new Date).getTime() + Math.random();
				flash = getFlashObject(this.id, a, t);
				if (!flash) {
					this.initialized = false;
					a.innerHTML = "flash加载失败"
				} else {
					var i = this;
					shipxyMap.flashInitialized = function(e) {
						if (e == 1) {
							i.initialized = true
						} else {
							i.initialized = false
						}
						delete shipxyMap.flashInitialized
					}
				}
			} else {
				return new shipxyMap.Map(e, t)
			}
		},
		MapOptions: function() {
			if (this instanceof shipxyMap.MapOptions) {
				this.center = new shipxyMap.LatLng(30, 122);
				this.zoom = 5;
				this.mapType = shipxyMap.MapType.GOOGLEMAP;
				this.mapTypes = [shipxyMap.MapType.CMAP, shipxyMap.MapType.GOOGLEMAP, shipxyMap.MapType.GOOGLESATELLITE]
			} else {
				return new shipxyMap.MapOptions
			}
		},
		MapType: {
			CMAP: "cmap",
			GOOGLEMAP: "googlemap",
			GOOGLESATELLITE: "googlesatellite",
			getName: function(e) {
				switch (e) {
				case this.CMAP:
					return "海图";
				case this.GOOGLEMAP:
					return "地图";
				case this.GOOGLESATELLITE:
					return "卫星图"
				}
			}
		},
		LatLng: function(e, t) {
			if (this instanceof shipxyMap.LatLng) {
				if (typeof e !== "number" || typeof t !== "number" || isNaN(e) || isNaN(t)) {
					throw new Error("shipxyMap.LatLng构造函数参数必须是有效数值")
				}
				this.lat = e;
				this.lng = t
			} else {
				return new shipxyMap.LatLng(e, t)
			}
		},
		LatLngBounds: function(e, t) {
			if (this instanceof shipxyMap.LatLngBounds) {
				if (!(e && e instanceof shipxyMap.LatLng) || !(t && e instanceof shipxyMap.LatLng)) {
					throw new Error("shipxyMap.LatLngBounds构造函数参数不能为空，且必须是shipxyMap.LatLng的实例")
				}
				this.southWest = e;
				this.northEast = t
			} else {
				return new shipxyMap.LatLngBounds(e, t)
			}
		},
		Point: function(e, t) {
			if (this instanceof shipxyMap.Point) {
				if (typeof e !== "number" || typeof t !== "number" || isNaN(e) || isNaN(t)) {
					throw new Error("shipxyMap.Point构造函数参数必须是有效数值")
				}
				this.x = e;
				this.y = t
			} else {
				return new shipxyMap.Point(e, t)
			}
		},
		Size: function(e, t) {
			if (this instanceof shipxyMap.Size) {
				if (typeof e !== "number" || typeof t !== "number" || isNaN(e) || isNaN(t)) {
					throw new Error("shipxyMap.Size构造函数参数必须是有效数值")
				}
				this.width = e;
				this.height = t
			} else {
				return new shipxyMap.Size(e, t)
			}
		},
		Overlay: function(e, t) {
			if (this instanceof shipxyMap.Overlay) {
				this.type = shipxyMap.OverlayType.OVERLAY;
				this.id = e || this.type + (new Date).getTime() + Math.random();
				this.options = t || new shipxyMap.OverlayOptions;
				if (typeof e !== "string") {
					throw new Error("请为shipxyMap.Overlay或其继承子类构造函数第一个参数指定为字符串值，而且应该是一个有效的能够唯一标识叠加物对象的ID")
				}
				if (!(t instanceof shipxyMap.OverlayOptions)) {
					throw new Error("请为shipxyMap.Overlay构造函数第二个参数指定为shipxyMap.OverlayOptions的一个实例，或者为空值采用默认内容")
				}
			} else {
				return new shipxyMap.Overlay(e, t)
			}
		},
		OverlayOptions: function() {
			if (this instanceof shipxyMap.OverlayOptions) {
				this.zoomlevels = [1, 18]
			} else {
				return new shipxyMap.OverlayOptions
			}
		},
		OverlayType: {
			OVERLAY: "overlay",
			SHIP: "ship",
			TRACK: "track",
			MARKER: "marker",
			POLYLINE: "polyline",
			POLYGON: "polygon"
		},
		Ship: function(e, t, a) {
			if (this instanceof shipxyMap.Ship) {
				if (t && !(t instanceof shipxyAPI.Ship)) {
					throw new Error("请为shipxyMap.Ship构造函数第二个参数指定为shipxyAPI.Ship的一个实例")
				}
				a = a || new shipxyMap.ShipOptions;
				if (!(a instanceof shipxyMap.ShipOptions)) {
					throw new Error("请为shipxyMap.Ship构造函数第三个参数指定为shipxyMap.ShipOptions的一个实例，或者为空值采用默认内容")
				}
				shipxyMap.Overlay.call(this, e, a);
				this.type = shipxyMap.OverlayType.SHIP;
				this.data = t
			} else {
				return new shipxyMap.Ship(e, t, a)
			}
		},
		ShipOptions: function() {
			if (this instanceof shipxyMap.ShipOptions) {
				shipxyMap.OverlayOptions.call(this);
				this.isShowLabel = true;
				this.isShowMiniTrack = true;
				this.isSelected = false;
				this.strokeStyle = new shipxyMap.StrokeStyle;
				this.fillStyle = new shipxyMap.FillStyle;
				this.fillStyle.color = 16776960;
				this.labelOptions = new shipxyMap.LabelOptions
			} else {
				return new shipxyMap.ShipOptions
			}
		},
		Track: function(e, t, a) {
			if (this instanceof shipxyMap.Track) {
				if (t && !(t instanceof shipxyAPI.Track)) {
					throw new Error("请为shipxyMap.Track构造函数第二个参数指定为shipxyAPI.Track的一个实例")
				}
				a = a || new shipxyMap.TrackOptions;
				if (!(a instanceof shipxyMap.TrackOptions)) {
					throw new Error("请为shipxyMap.Track构造函数第三个参数指定为shipxyMap.TrackOptions的一个实例，或者为空值采用默认内容")
				}
				shipxyMap.Overlay.call(this, e, a);
				this.type = shipxyMap.OverlayType.TRACK;
				this.data = t
			} else {
				return new shipxyMap.Track(e, t, a)
			}
		},
		TrackOptions: function() {
			if (this instanceof shipxyMap.TrackOptions) {
				shipxyMap.OverlayOptions.call(this);
				this.isShowLabel = true;
				this.isVacuate = true;
				this.distance = 50;
				this.pointStyle = new shipxyMap.PointStyle;
				this.pointStyle.radius = 4;
				this.pointStyle.fillStyle.color = 16777215;
				this.strokeStyle = new shipxyMap.StrokeStyle;
				this.strokeStyle.thickness = 2;
				this.labelOptions = new shipxyMap.LabelOptions
			} else {
				return new shipxyMap.TrackOptions
			}
		},
		Marker: function(e, t, a) {
			if (this instanceof shipxyMap.Marker) {
				if (!t || !(t instanceof shipxyMap.LatLng)) {
					throw new Error("请为shipxyMap.Marker构造函数第二个参数指定内容，必须是shipxyMap.LatLng的一个实例")
				}
				a = a || new shipxyMap.MarkerOptions;
				if (!(a instanceof shipxyMap.MarkerOptions)) {
					throw new Error("请为shipxyMap.Marker构造函数第三个参数指定为shipxyMap.MarkerOptions的一个实例，或者为空值采用默认内容")
				}
				shipxyMap.Overlay.call(this, e, a);
				this.type = shipxyMap.OverlayType.MARKER;
				this.data = t
			} else {
				return new shipxyMap.Marker(e, t, a)
			}
		},
		MarkerOptions: function() {
			if (this instanceof shipxyMap.MarkerOptions) {
				shipxyMap.OverlayOptions.call(this);
				this.zIndex = shipxyMap.ZIndexConst.OVERLAY_LAYER;
				this.imageUrl = "";
				this.imagePos = new shipxyMap.Point(0, 0);
				this.isShowLabel = false;
				this.isEditable = false;
				this.labelOptions = new shipxyMap.LabelOptions;
				this.labelOptions.text = "这是一个点标注"
			} else {
				return new shipxyMap.MarkerOptions
			}
		},
		Polyline: function(e, t, a) {
			if (this instanceof shipxyMap.Polyline) {
				if (!t || !(t instanceof Array)) {
					throw new Error("请为shipxyMap.Polyline构造函数第二个参数指定内容，一个数组，元素可以是shipxyMap.LatLng实例，也可以是如{lat:0,lng:0}格式的内容")
				}
				a = a || new shipxyMap.PolylineOptions;
				if (!(a instanceof shipxyMap.PolylineOptions)) {
					throw new Error("请为shipxyMap.Polyline构造函数第三个参数指定为shipxyMap.PolylineOptions的一个实例，或者为空值采用默认内容")
				}
				var i, r = t.length;
				for (var s = 0; s < r; s++) {
					i = t[s];
					if (!(i instanceof shipxyMap.LatLng)) {
						t[s] = new shipxyMap.LatLng(i.lat, i.lng)
					}
				}
				shipxyMap.Overlay.call(this, e, a);
				this.type = shipxyMap.OverlayType.POLYLINE;
				this.data = t
			} else {
				return new shipxyMap.Polyline(e, t, a)
			}
		},
		PolylineOptions: function() {
			if (this instanceof shipxyMap.PolylineOptions) {
				shipxyMap.OverlayOptions.call(this);
				this.zIndex = shipxyMap.ZIndexConst.OVERLAY_LAYER;
				this.isShowLabel = false;
				this.isEditable = false;
				this.strokeStyle = new shipxyMap.StrokeStyle;
				this.strokeStyle.color = 26279;
				this.strokeStyle.thickness = 2;
				this.labelOptions = new shipxyMap.LabelOptions;
				this.labelOptions.text = "这是一条折线"
			} else {
				return new shipxyMap.PolylineOptions
			}
		},
		Polygon: function(e, t, a) {
			if (this instanceof shipxyMap.Polygon) {
				if (!t || !(t instanceof Array)) {
					throw new Error("请为shipxyMap.Polygon构造函数第二个参数指定内容，一个数组，元素可以是shipxyMap.LatLng实例，也可以是如{lat:0,lng:0}格式的内容")
				}
				a = a || new shipxyMap.PolygonOptions;
				if (!(a instanceof shipxyMap.PolygonOptions)) {
					throw new Error("请为shipxyMap.Polygon构造函数第三个参数指定为shipxyMap.PolygonOptions的一个实例，或者为空值采用默认内容")
				}
				var i, r = t.length;
				for (var s = 0; s < r; s++) {
					i = t[s];
					if (!(i instanceof shipxyMap.LatLng)) {
						t[s] = new shipxyMap.LatLng(i.lat, i.lng)
					}
				}
				shipxyMap.Overlay.call(this, e, a);
				this.type = shipxyMap.OverlayType.POLYGON;
				this.data = t
			} else {
				return new shipxyMap.Polygon(e, t, a)
			}
		},
		PolygonOptions: function() {
			if (this instanceof shipxyMap.PolygonOptions) {
				shipxyMap.OverlayOptions.call(this);
				this.zIndex = shipxyMap.ZIndexConst.OVERLAY_LAYER;
				this.isShowLabel = false;
				this.isEditable = false;
				this.strokeStyle = new shipxyMap.StrokeStyle;
				this.strokeStyle.color = 26279;
				this.strokeStyle.thickness = 2;
				this.fillStyle = new shipxyMap.FillStyle;
				this.fillStyle.color = 255;
				this.fillStyle.alpha = .2;
				this.labelOptions = new shipxyMap.LabelOptions;
				this.labelOptions.text = "这是一个多边形"
			} else {
				return new shipxyMap.PolygonOptions
			}
		},
		LabelOptions: function() {
			if (this instanceof shipxyMap.LabelOptions) {
				shipxyMap.OverlayOptions.call(this);
				this.text = "";
				this.htmlText = "";
				this.labelPosition = new shipxyMap.Point(0, 0);
				this.fontStyle = new shipxyMap.FontStyle;
				this.border = true;
				this.background = false;
				this.borderStyle = new shipxyMap.StrokeStyle;
				this.backgroundStyle = new shipxyMap.FillStyle
			} else {
				return new shipxyMap.LabelOptions
			}
		},
		PointStyle: function() {
			if (this instanceof shipxyMap.PointStyle) {
				this.radius = 1;
				this.strokeStyle = new shipxyMap.StrokeStyle;
				this.fillStyle = new shipxyMap.FillStyle
			} else {
				return new shipxyMap.PointStyle
			}
		},
		StrokeStyle: function() {
			if (this instanceof shipxyMap.StrokeStyle) {
				this.thickness = 1;
				this.color = 0;
				this.alpha = 1
			} else {
				return new shipxyMap.StrokeStyle
			}
		},
		FillStyle: function() {
			if (this instanceof shipxyMap.FillStyle) {
				this.color = 0;
				this.alpha = 1
			} else {
				return new shipxyMap.FillStyle
			}
		},
		FontStyle: function() {
			if (this instanceof shipxyMap.FontStyle) {
				this.name = "Verdana";
				this.size = 11;
				this.color = 0;
				this.bold = false;
				this.italic = false;
				this.underline = false
			} else {
				return new shipxyMap.FontStyle
			}
		},
		Event: function() {
			if (this instanceof shipxyMap.Event) {
				this.mapId = "";
				this.overlayId = "";
				this.type = "";
				this.latLng = null;
				this.zoom = NaN;
				this.extendData = null
			} else {
				return new shipxyMap.Event
			}
		},
		JS_AS: {
			addCallbackHook: function(e) {
				if (e && e instanceof Function) {
					var t = "",
						a = false;
					for (var i in jsCallbackHook) {
						if (jsCallbackHook[i] == e) {
							t = i;
							a = true;
							break
						}
					}
					if (!a) {
						t = "jscallback:" + (new Date).getTime() + Math.random();
						jsCallbackHook[t] = e
					}
					return [shipxyMap.name + ".JS_AS.callCallbackHook", t]
				}
			},
			callCallbackHook: function() {
				var e = arguments[0];
				if (jsCallbackHook[e]) {
					jsCallbackHook[e].apply(this, arguments);
					delete jsCallbackHook[e]
				} else {
					if (this[e]) this[e].apply(this, arguments)
				}
			},
			addJSEventHook: function(e) {
				if (e && e instanceof Function) {
					var t = "",
						a = false;
					for (var i in jsEventHook) {
						if (jsEventHook[i] == e) {
							t = i;
							a = true;
							break
						}
					}
					if (!a) {
						t = "jsevent:" + (new Date).getTime() + Math.random();
						jsEventHook[t] = e
					}
					return [shipxyMap.name + ".JS_AS.callJSEventHook", t]
				}
			},
			callJSEventHook: function(e, t) {
				var a = new shipxyMap.Event;
				if (t.mapId) {
					a.mapId = t.mapId
				}
				if (t.overlayId) {
					a.overlayId = t.overlayId
				}
				if (t.type) {
					a.type = t.type
				}
				if (t.lat && t.lng) {
					a.latLng = new shipxyMap.LatLng(t.lat, t.lng)
				}
				if (t.zoom) {}
				a.zoom = t.zoom;
				if (t.extendData) {
					a.extendData = t.extendData
				}
				jsEventHook[e].call(this, a)
			},
			removeJSEventHook: function(e) {
				if (e && e instanceof Function) {
					var t = "";
					for (var a in jsEventHook) {
						if (jsEventHook[a] == e) {
							t = a;
							delete jsEventHook[t];
							return [shipxyMap.name + ".JS_AS.callJSEventHook", t]
						}
					}
					return null
				}
			},
			log: function(e) {
				console.log("log from flash:" + e)
			}
		},
		ZIndexConst: {
			MAP_LAYER: 1,
			SHIP_LAYER: 2,
			TRACK_LAYER: 3,
			OVERLAY_LAYER: 4
		}
	};
	shipxyMap.Map.prototype = {
		setCenter: function(e, t) {
			if (e && e instanceof shipxyMap.LatLng) {
				var a = typeof t == "number";
				if (t && !a) {
					throw new Error("请为setCenter方法第二个参数指定为一个数值或者不传")
				} else if (a) {
					t = Math.round(t);
					if (isNaN(t) || t < 1 || t > 18) {
						throw new Error("setCenter方法第二个参数的数值范围必须是1~18之间的整数或者不传")
					}
				}
				try {
					flash.setCenter(toObject(e), t);
					this.center = e;
					if (t) {
						this.zoom = t
					}
				} catch (i) {
					throwFlashError("setCenter", i.message)
				}
			} else {
				throw new Error("setCenter方法参数错误，参数latLng不能为空，且必须是shipxyMap.LatLng的一个实例")
			}
		},
		getCenter: function() {
			if (!this.initialized) {
				return this.center
			}
			try {
				var e = flash.getCenter();
				if (e) {
					this.center.lat = e.lat;
					this.center.lng = e.lng;
					return this.center
				}
				return null
			} catch (t) {
				throwFlashError("getCenter", t.message)
			}
		},
		setZoom: function(e) {
			if (typeof e != "number" || isNaN(e)) {
				throw new Error("请为setZoom方法参数指定为一个1~18之间的整数值")
			} else {
				e = Math.round(e);
				if (e < 1 || e > 18) {
					throw new Error("setZoom方法参数的数值范围必须是1~18之间的整数")
				}
			}
			try {
				flash.setZoom(e);
				this.zoom = e
			} catch (t) {
				throwFlashError("setZoom", t.message)
			}
		},
		getZoom: function() {
			if (!this.initialized) {
				return this.zoom
			}
			try {
				this.zoom = flash.getZoom();
				return this.zoom
			} catch (e) {
				throwFlashError("getZoom", e.message)
			}
		},
		setMapType: function(e) {
			e = e || shipxyMap.MapType.GOOGLEMAP;
			if (typeof e != "string") {
				throw new Error("请为setMapType方法参数指定为一个字符串值或者不传")
			} else {
				var t = shipxyMap.MapType;
				var a = false;
				for (var i in t) {
					if (e == t[i]) {
						a = true;
						break
					}
				}
				if (!a) {
					throw new Error("setMapType方法参数必须是shipxyMap.MapType所列出的地图类型之一，注意大小写")
				}
			}
			try {
				flash.setMapType(e);
				this.mapType = e
			} catch (r) {
				throwFlashError("setMapType", r.message)
			}
		},
		getMapType: function() {
			if (!this.initialized) {
				return this.mapType
			}
			try {
				this.mapType = flash.getMapType();
				return this.mapType
			} catch (e) {
				throwFlashError("getMapType", e.message)
			}
		},
		getSize: function() {
			if (!this.initialized) {
				return null
			}
			try {
				var e = flash.getSize();
				if (e) {
					return new shipxyMap.Size(e.width, e.height)
				}
				return null
			} catch (t) {
				throwFlashError("getSize", t.message)
			}
		},
		getLatLngBounds: function() {
			if (!this.initialized) {
				return null
			}
			try {
				var e = flash.getLatLngBounds();
				if (e) {
					var t = new shipxyMap.LatLng(e.southWest.lat, e.southWest.lng);
					var a = new shipxyMap.LatLng(e.northEast.lat, e.northEast.lng);
					return new shipxyMap.LatLngBounds(t, a)
				}
				return null
			} catch (i) {
				throwFlashError("getLatLngBounds", i.message)
			}
		},
		zoomIn: function() {
			try {
				return flash.zoomIn()
			} catch (e) {
				throwFlashError("zoomIn", e.message)
			}
		},
		zoomOut: function() {
			try {
				return flash.zoomOut()
			} catch (e) {
				throwFlashError("zoomOut", e.message)
			}
		},
		panTo: function(e) {
			if (e && e instanceof shipxyMap.LatLng) {
				try {
					flash.panTo(toObject(e))
				} catch (t) {
					throwFlashError("panTo", t.message)
				}
			} else {
				throw new Error("panTo方法参数错误，参数不能为空，且必须是shipxyMap.LatLng的一个实例")
			}
		},
		panBy: function(e) {
			if (e && e instanceof shipxyMap.Size) {
				try {
					flash.panBy(toObject(e))
				} catch (t) {
					throwFlashError("panBy", t.message)
				}
			} else {
				throw new Error("panBy方法参数错误，参数不能为空，且必须是shipxyMap.Size的一个实例")
			}
		},
		addOverlay: function(e, t) {
			if (e && e instanceof shipxyMap.Overlay) {
				if (t != undefined && typeof t != "boolean") {
					throw new Error("addOverlay方法第二个参数错误，需要是布尔值或者不填")
				}
				try {
					flash.addOverlay(toObject(e), t);
					overlayList[e.id] = e
				} catch (a) {
					throwFlashError("addOverlay", a.message)
				}
			} else {
				throw new Error("addOverlay方法参数错误，参数不能为空，且必须是shipxyMap.Overlay或其子类的一个实例")
			}
		},
		addOverlays: function(e) {
			if (e && e instanceof Array) {
				for (var t = 0, a = e.length; t < a; t++) {
					this.addOverlay(e[t])
				}
			} else {
				throw new Error("addOverlays方法参数错误，参数不能为空，且必须是Array数组实例")
			}
		},
		removeOverlay: function(e) {
			if (e && e instanceof shipxyMap.Overlay) {
				try {
					flash.removeOverlay(toObject(e));
					delete overlayList[e.id]
				} catch (t) {
					throwFlashError("removeOverlay", t.message)
				}
			} else {
				throw new Error("removeOverlay方法参数错误，参数不能为空，且必须是shipxyMap.Overlay或其子类的一个实例")
			}
		},
		removeOverlays: function(e) {
			if (e && e instanceof Array) {
				for (var t = 0, a = e.length; t < a; t++) {
					this.removeOverlay(e[t])
				}
			} else {
				throw new Error("removeOverlays方法参数错误，参数不能为空，且必须是Array数组实例")
			}
		},
		removeOverlayById: function(e) {
			if (e && typeof e == "string") {
				this.removeOverlay(this.getOverlayById(e))
			} else {
				throw new Error("removeOverlayById方法参数错误，参数不能为空，且必须是字符串值，而且应该是一个有效的能够唯一标识叠加物对象的ID")
			}
		},
		removeOverlayByType: function(e) {
			if (e && typeof e == "string") {
				var t = shipxyMap.OverlayType;
				var a = false;
				for (var i in t) {
					if (e == t[i]) {
						a = true;
						break
					}
				}
				if (!a) {
					throw new Error("removeOverlayByType方法参数错误，参数必须是shipxyMap.OverlayType所列出的叠加物类型之一，注意大小写")
				}
				this.removeOverlays(this.getOverlayByType(e))
			} else {
				throw new Error("removeOverlayByType方法参数错误，参数不能为空，且必须是字符串值")
			}
		},
		removeAllOverlay: function() {
			for (var e in overlayList) {
				var t = overlayList[e];
				if (!(t instanceof Function)) {
					this.removeOverlay(overlayList[e])
				}
			}
			overlayList = {}
		},
		getOverlayById: function(e) {
			if (e && typeof e == "string") {
				var t = overlayList[e];
				if (t) {
					if (t.type == shipxyMap.OverlayType.MARKER || t.type == shipxyMap.OverlayType.POLYLINE || t.type == shipxyMap.OverlayType.POLYGON) {
						var a = flash.getOverlay(e);
						if (a) {
							var i, r;
							switch (a.type) {
							case shipxyMap.OverlayType.MARKER:
								t.data.lat = a.data.lat;
								t.data.lng = a.data.lng;
								break;
							case shipxyMap.OverlayType.POLYLINE:
							case shipxyMap.OverlayType.POLYGON:
								var s = [],
									n = a.data,
									o;
								for (var p = 0, h = n.length; p < h; p++) {
									o = n[p];
									s.push(new shipxyMap.LatLng(o.lat, o.lng))
								}
								t.data = s;
								break
							}
						}
					}
				}
				return t
			} else {
				throw new Error("getOverlayById方法参数错误，参数不能为空，且必须是字符串值，而且应该是一个有效的能够唯一标识叠加物对象的ID")
			}
		},
		getOverlayByType: function(e) {
			if (e && typeof e == "string") {
				var t = shipxyMap.OverlayType;
				var a = false;
				for (var i in t) {
					if (e == t[i]) {
						a = true;
						break
					}
				}
				if (!a) {
					throw new Error("getOverlayByType方法参数错误，参数必须是shipxyMap.OverlayType所列出的叠加物类型之一，注意大小写")
				}
				var r = [],
					s = null;
				for (var n in overlayList) {
					s = overlayList[n];
					if (s && s.type == e) {
						r.push(this.getOverlayById(n))
					}
				}
				return r
			} else {
				throw new Error("getOverlayByType方法参数错误，参数不能为空，且必须是字符串值")
			}
		},
		locateOverlay: function(e, t) {
			if (e && e instanceof shipxyMap.Overlay) {
				var a = typeof t == "number";
				if (t && !a) {
					throw new Error("请为locateOverlay方法第二个参数指定为一个数值或者不传")
				} else if (a) {
					t = Math.round(t);
					if (isNaN(t) || t < 1 || t > 18) {
						throw new Error("locateOverlay方法第二个参数的数值范围必须是1~18之间的整数或者不传")
					}
				}
				try {
					flash.locateOverlay(toObject(e), t)
				} catch (i) {
					throwFlashError("locateOverlay", i.message)
				}
			} else {
				throw new Error("locateOverlay方法参数错误，第一个参数不能为空，且必须是shipxyMap.Overlay或其子类的一个实例")
			}
		},
		locateOverlayById: function(e, t) {
			if (e && typeof e == "string") {
				this.locateOverlay(this.getOverlayById(e), t)
			} else {
				throw new Error("locateOverlayById方法参数错误，第一个参数不能为空，且必须是字符串值，而且应该是一个有效的能够唯一标识叠加物对象的ID")
			}
		},
		locateOverlayByType: function(e, t) {
			if (e && typeof e == "string") {
				var a = shipxyMap.OverlayType;
				var i = false;
				for (var r in a) {
					if (e == a[r]) {
						i = true;
						break
					}
				}
				if (!i) {
					throw new Error("removeOverlayByType方法参数错误，参数必须是shipxyMap.OverlayType所列出的叠加物类型之一，注意大小写")
				}
				this.locateOverlays(this.getOverlayByType(e), t)
			} else {
				throw new Error("locateOverlayByType方法参数错误，参数不能为空，且必须是字符串值")
			}
		},
		locateOverlays: function(e, t) {
			if (e && e instanceof Array) {
				var a = typeof t == "number";
				if (t && !a) {
					throw new Error("请为locateOverlays方法第二个参数指定为一个数值或者不传")
				} else if (a) {
					t = Math.round(t);
					if (isNaN(t) || t < 1 || t > 18) {
						throw new Error("locateOverlays方法第二个参数的数值范围必须是1~18之间的整数或者不传")
					}
				}
				var i = [],
					r = null;
				for (var s in e) {
					r = e[s];
					if (!(r instanceof Function)) {
						if (r instanceof shipxyMap.Overlay) {
							i.push(toObject(r))
						} else {
							throw new Error("locateOverlays方法参数错误，第一个参数的数组元素必须是shipxyMap.Overlay或其子类的实例")
						}
					}
				}
				try {
					flash.locateOverlays(i, t)
				} catch (n) {
					throwFlashError("locateOverlays", n.message)
				}
			} else {
				throw new Error("locateOverlays方法参数错误，第一个参数不能为空，且必须是Array数组实例")
			}
		},
		fromLatLngToPoint: function(e) {
			if (e && e instanceof shipxyMap.LatLng) {
				try {
					var t = flash.fromLatLngToPoint(toObject(e));
					if (t) {
						return new shipxyMap.Point(t.x, t.y)
					}
					return null
				} catch (a) {
					throwFlashError("fromLatLngToPoint", a.message)
				}
			} else {
				throw new Error("fromLatLngToPoint方法参数错误，参数不能为空，且必须是shipxyMap.LatLng的一个实例")
			}
		},
		fromPointToLatLng: function(e) {
			if (e && e instanceof shipxyMap.Point) {
				try {
					var t = flash.fromPointToLatLng(toObject(e));
					if (t) {
						return new shipxyMap.LatLng(t.lat, t.lng)
					}
					return null
				} catch (a) {
					throwFlashError("fromPointToLatLng", a.message)
				}
			} else {
				throw new Error("fromPointToLatLng方法参数错误，参数不能为空，且必须是shipxyMap.Point的一个实例")
			}
		},
		addEventListener: function(e, t, a) {
			if (e && (e instanceof shipxyMap.Map || e instanceof shipxyMap.Overlay) && t && typeof t == "string" && a && a instanceof Function) {
				try {
					var i = shipxyMap.JS_AS.addJSEventHook(a);
					if (i) {
						flash.addEventListener(e.id, t, i)
					}
				} catch (r) {
					throwFlashError("addEventListener", r.message)
				}
			} else {
				throw new Error("addEventListener方法参数错误，三个参数都不能为空，第一个参数是shipxyMap.Map/shipxyMap.Overlay或其子类的实例，第二个参数是事件类型，第三个参数是事件回调函数")
			}
		},
		removeEventListener: function(e, t, a) {
			if (e && (e instanceof shipxyMap.Map || e instanceof shipxyMap.Overlay) && t && typeof t == "string" && a && a instanceof Function) {
				try {
					var i = shipxyMap.JS_AS.removeJSEventHook(a);
					if (i) {
						flash.removeEventListener(e.id, t, i)
					}
				} catch (r) {
					throwFlashError("removeEventListener", r.message)
				}
			} else {
				throw new Error("removeEventListener方法参数错误，三个参数都不能为空，第一个参数是shipxyMap.Map/shipxyMap.Overlay或其子类的实例，第二个参数是事件类型值，第三个参数是事件回调函数")
			}
		},
		addShipEventListener: function(e, t) {
			if (e && typeof e == "string" && t && t instanceof Function) {
				try {
					var a = shipxyMap.JS_AS.addJSEventHook(t);
					if (a) {
						flash.addShipEventListener(e, a)
					}
				} catch (i) {
					throwFlashError("addShipEventListener", i.message)
				}
			} else {
				throw new Error("addShipEventListener方法参数不正确")
			}
		},
		removeShipEventListener: function(e, t) {
			if (e && typeof e == "string" && t && t instanceof Function) {
				try {
					var a = shipxyMap.JS_AS.removeJSEventHook(t);
					if (a) {
						flash.removeShipEventListener(e, a)
					}
				} catch (i) {
					throwFlashError("removeShipEventListener", i.message)
				}
			} else {
				throw new Error("removeShipEventListener方法参数不正确")
			}
		},
		showShipForecast: function(e) {
			flash.showShipForecast(e)
		}
	};
	shipxyMap.LatLng.prototype = {
		clone: function() {
			return new shipxyMap.LatLng(this.lat, this.lng)
		}
	};
	shipxyMap.LatLngBounds.prototype = {
		clone: function() {
			return new shipxyMap.LatLngBounds(this.southWest.clone(), this.northEast.clone())
		}
	};
	shipxyMap.Point.prototype = {
		clone: function() {
			return new shipxyMap.Point(this.x, this.y)
		}
	};
	shipxyMap.Size.prototype = {
		clone: function() {
			return new shipxyMap.Size(this.width, this.height)
		}
	};
	inheritPrototype(shipxyMap.Ship, shipxyMap.Overlay);
	inheritPrototype(shipxyMap.ShipOptions, shipxyMap.OverlayOptions);
	inheritPrototype(shipxyMap.Track, shipxyMap.Overlay);
	inheritPrototype(shipxyMap.TrackOptions, shipxyMap.OverlayOptions);
	inheritPrototype(shipxyMap.Marker, shipxyMap.Overlay);
	inheritPrototype(shipxyMap.MarkerOptions, shipxyMap.OverlayOptions);
	inheritPrototype(shipxyMap.Polyline, shipxyMap.Overlay);
	inheritPrototype(shipxyMap.PolylineOptions, shipxyMap.OverlayOptions);
	inheritPrototype(shipxyMap.Polygon, shipxyMap.Overlay);
	inheritPrototype(shipxyMap.PolygonOptions, shipxyMap.OverlayOptions);
	inheritPrototype(shipxyMap.LabelOptions, shipxyMap.OverlayOptions);
	shipxyMap.Event.MOVE_END = "move_end";
	shipxyMap.Event.ZOOM_CHANGED = "zoom_changed";
	shipxyMap.Event.MAPTYPE_CHANGED = "maptype_changed";
	shipxyMap.Event.OVERLAY_ADDED = "overlay_added";
	shipxyMap.Event.OVERLAY_REMOVED = "overlay_removed";
	shipxyMap.Event.CLICK = "click";
	shipxyMap.Event.DOUBLE_CLICK = "doubleClick";
	shipxyMap.Event.MOUSE_DOWN = "mouseDown";
	shipxyMap.Event.MOUSE_MOVE = "mouseMove";
	shipxyMap.Event.MOUSE_UP = "mouseUp";
	shipxyMap.Event.MOUSE_OVER = "mouseOver";
	shipxyMap.Event.MOUSE_OUT = "mouseOut";
	shipxyMap.Event.TRACKPOINT_CLICK = "trackpoint_click";
	shipxyMap.Event.TRACKPOINT_MOUSEOVER = "trackpoint_mouseover";
	shipxyMap.Event.TRACKPOINT_MOUSEOUT = "trackpoint_mouseout"
}();