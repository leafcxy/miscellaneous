!
function() {
	var t = "http://api.shipxy.com/apdll/ap.dll";
	var e = 2;
	var r = 0;
	var a = function(t, e, r) {
			function a() {}
			a.prototype = e.prototype;
			var i = new a;
			i.constructor = t;
			if (r) {
				for (var n in r) {
					if (r.hasOwnProperty(n)) i[n] = r[n]
				}
			}
			t.prototype = i
		};
	var i = 0;
	var n = function(t, e) {
			if (this instanceof n) {
				this.options = e || {};
				this.options.timeout = this.options.hasOwnProperty("timeout") ? this.options.timeout : 0;
				this.options.callback = this.options.hasOwnProperty("callback") ? this.options.callback : "callback";
				this.requestID = this.options.callback + "_" + ++i;
				this.serverCallback = "shipxyAPI." + this.requestID + "_callback";
				this.url = t + (t.indexOf("?") == -1 ? "?" : "&") + this.options.callback + "=" + this.serverCallback;
				this.scriptElement = null;
				this.timeoutWatcher = 0
			} else {
				return new n(t, e)
			}
		};
	n.prototype = {
		send: function() {
			try {
				this.scriptElement = document.createElement("script");
				this.scriptElement.setAttribute("id", this.requestID);
				this.scriptElement.setAttribute("type", "text/javascript");
				var t = this;
				if (this.options.timeout > 0) {
					this.timeoutWatcher = setTimeout(function() {
						t.abort();
						if (t.options.error) {
							t.options.error.call(t)
						}
					}, this.options.timeout)
				}
				shipxyAPI[this.serverCallback.substr(10)] = function(e) {
					if (t.options.success) {
						t.options.success.call(t, e)
					}
					t.abort()
				};
				this.scriptElement.setAttribute("src", this.url);
				document.getElementsByTagName("head")[0].appendChild(this.scriptElement)
			} catch (e) {
				t.abort();
				if (t.options.error) {
					t.options.error.call(t)
				}
			}
		},
		abort: function() {
			clearTimeout(this.timeoutWatcher);
			this.timeoutWatcher = 0;
			this.scriptElement.parentNode.removeChild(this.scriptElement);
			this.scriptElement = null;
			delete shipxyAPI[this.serverCallback.substr(10)]
		}
	};
	var s = {
		encodeChars: ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "/"],
		decodeChars: [-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 62, -1, -1, -1, 63, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, -1, -1, -1, -1, -1, -1, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, -1, -1, -1, -1, -1, -1, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, -1, -1, -1, -1, -1],
		encode64: function(t) {
			var e, r, a, i;
			var n, s, o;
			i = t.length;
			r = a = 0;
			e = [];
			while (r < i) {
				n = t.charCodeAt(r++) & 255;
				if (r == i) {
					e[a++] = this.encodeChars[n >> 2];
					e[a++] = this.encodeChars[(n & 3) << 4];
					e[a++] = "==";
					break
				}
				s = t.charCodeAt(r++) & 255;
				if (r == i) {
					e[a++] = this.encodeChars[n >> 2];
					e[a++] = this.encodeChars[(n & 3) << 4 | (s & 240) >> 4];
					e[a++] = this.encodeChars[(s & 15) << 2];
					e[a++] = "=";
					break
				}
				o = t.charCodeAt(r++) & 255;
				e[a++] = this.encodeChars[n >> 2];
				e[a++] = this.encodeChars[(n & 3) << 4 | (s & 240) >> 4];
				e[a++] = this.encodeChars[(s & 15) << 2 | (o & 192) >> 6];
				e[a++] = this.encodeChars[o & 63]
			}
			return e.join("")
		},
		decode64: function(t) {
			var e, r, a, i;
			var n, s, o, h;
			o = t.length;
			n = s = 0;
			h = [];
			while (n < o) {
				do {
					e = this.decodeChars[t.charCodeAt(n++) & 255]
				} while (n < o && e == -1);
				if (e == -1) break;
				do {
					r = this.decodeChars[t.charCodeAt(n++) & 255]
				} while (n < o && r == -1);
				if (r == -1) break;
				h[s++] = String.fromCharCode(e << 2 | (r & 48) >> 4);
				do {
					a = t.charCodeAt(n++) & 255;
					if (a == 61) return h.join("");
					a = this.decodeChars[a]
				} while (n < o && a == -1);
				if (a == -1) break;
				h[s++] = String.fromCharCode((r & 15) << 4 | (a & 60) >> 2);
				do {
					i = t.charCodeAt(n++) & 255;
					if (i == 61) return h.join("");
					i = this.decodeChars[i]
				} while (n < o && i == -1);
				if (i == -1) break;
				h[s++] = String.fromCharCode((a & 3) << 6 | i)
			}
			return h.join("")
		},
		utf16to8: function(t) {
			var e, r, a, i;
			e = "";
			a = t.length;
			for (r = 0; r < a; r++) {
				i = t.charCodeAt(r);
				if (i >= 1 && i <= 127) {
					e += t.charAt(r)
				} else if (i > 2047) {
					e += String.fromCharCode(224 | i >> 12 & 15);
					e += String.fromCharCode(128 | i >> 6 & 63);
					e += String.fromCharCode(128 | i >> 0 & 63)
				} else {
					e += String.fromCharCode(192 | i >> 6 & 31);
					e += String.fromCharCode(128 | i >> 0 & 63)
				}
			}
			return e
		},
		utf8to16: function(t) {
			var e, r, a, i;
			var n, s;
			e = "";
			a = t.length;
			r = 0;
			while (r < a) {
				i = t.charCodeAt(r++);
				switch (i >> 4) {
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
					e += t.charAt(r - 1);
					break;
				case 12:
				case 13:
					n = t.charCodeAt(r++);
					e += String.fromCharCode((i & 31) << 6 | n & 63);
					break;
				case 14:
					n = t.charCodeAt(r++);
					s = t.charCodeAt(r++);
					e += String.fromCharCode((i & 15) << 12 | (n & 63) << 6 | (s & 63) << 0);
					break
				}
			}
			return e
		}
	};
	var o = function(t, e) {
			this.data = t || "";
			this.endian = e || this.Endian.LITTLE;
			this.length = this.data.length;
			this.position = 0;
			this.TWOeN23 = Math.pow(2, -23);
			this.TWOeN52 = Math.pow(2, -52)
		};
	o.Endian = {
		BIG: 0,
		LITTLE: 1
	};
	o.prototype = {
		readByte: function() {
			return this.data.charCodeAt(this.position++) & 255
		},
		readBoolean: function() {
			return this.data.charCodeAt(this.position++) & 255 ? true : false
		},
		readUnsignedShort: function() {
			var t = this.data,
				e;
			if (this.endian == o.Endian.BIG) {
				e = (this.position += 2) - 2;
				return (t.charCodeAt(e) & 255) << 8 | t.charCodeAt(++e) & 255
			} else if (this.endian == o.Endian.LITTLE) {
				e = this.position += 2;
				return (t.charCodeAt(--e) & 255) << 8 | t.charCodeAt(--e) & 255
			}
		},
		readShort: function() {
			var t = this.data,
				e, r;
			if (this.endian == o.Endian.BIG) {
				e = (this.position += 2) - 2;
				r = (t.charCodeAt(e) & 255) << 8 | t.charCodeAt(++e) & 255
			} else if (this.endian == o.Endian.LITTLE) {
				e = this.position += 2;
				r = (t.charCodeAt(--e) & 255) << 8 | t.charCodeAt(--e) & 255
			}
			return r >= 32768 ? r - 65536 : r
		},
		readUnsignedInt: function() {
			var t = this.data,
				e;
			if (this.endian == o.Endian.BIG) {
				e = (this.position += 4) - 4;
				return (t.charCodeAt(e) & 255) << 24 | (t.charCodeAt(++e) & 255) << 16 | (t.charCodeAt(++e) & 255) << 8 | t.charCodeAt(++e) & 255
			} else if (this.endian == o.Endian.LITTLE) {
				e = this.position += 4;
				return (t.charCodeAt(--e) & 255) << 24 | (t.charCodeAt(--e) & 255) << 16 | (t.charCodeAt(--e) & 255) << 8 | t.charCodeAt(--e) & 255
			}
		},
		readInt: function() {
			var t = this.data,
				e, r;
			if (this.endian == o.Endian.BIG) {
				e = (this.position += 4) - 4;
				r = (t.charCodeAt(e) & 255) << 24 | (t.charCodeAt(++e) & 255) << 16 | (t.charCodeAt(++e) & 255) << 8 | t.charCodeAt(++e) & 255
			} else if (this.endian == o.Endian.LITTLE) {
				e = this.position += 4;
				r = (t.charCodeAt(--e) & 255) << 24 | (t.charCodeAt(--e) & 255) << 16 | (t.charCodeAt(--e) & 255) << 8 | t.charCodeAt(--e) & 255
			}
			return r >= 2147483648 ? r - 4294967296 : r
		},
		readUnsignedInt64: function() {
			var t = this.data,
				e;
			if (this.endian == o.Endian.BIG) {} else if (this.endian == o.Endian.LITTLE) {
				e = this.position;
				var r = (t.charCodeAt(e + 3) & 255) << 24 | (t.charCodeAt(e + 2) & 255) << 16 | (t.charCodeAt(e + 1) & 255) << 8 | t.charCodeAt(e) & 255;
				var a = (t.charCodeAt(e + 7) & 255) << 24 | (t.charCodeAt(e + 6) & 255) << 16 | (t.charCodeAt(e + 5) & 255) << 8 | t.charCodeAt(e + 4) & 255;
				this.position += 8;
				return a * 65536 * 65536 + r
			}
		},
		readInt64: function() {
			var t = this.data,
				e;
			if (this.endian == o.Endian.BIG) {} else if (this.endian == o.Endian.LITTLE) {
				e = this.position;
				var r = (t.charCodeAt(e + 3) & 255) << 24 | (t.charCodeAt(e + 2) & 255) << 16 | (t.charCodeAt(e + 1) & 255) << 8 | t.charCodeAt(e) & 255;
				var a = (t.charCodeAt(e + 7) & 255) << 24 | (t.charCodeAt(e + 6) & 255) << 16 | (t.charCodeAt(e + 5) & 255) << 8 | t.charCodeAt(e + 4) & 255;
				this.position += 8;
				var i = a * 65536 * 65536 + r;
				if (i > 4294967296 * 2147483648 - 1) {
					i -= 4294967296 * 4294967296
				}
				return i
			}
		},
		readFloat: function() {
			var t = this.data,
				e, r, a, i, n;
			if (this.endian == o.Endian.BIG) {
				e = (this.position += 4) - 4;
				r = t.charCodeAt(e) & 255;
				a = t.charCodeAt(++e) & 255;
				i = t.charCodeAt(++e) & 255;
				n = t.charCodeAt(++e) & 255
			} else if (this.endian == o.Endian.LITTLE) {
				e = this.position += 4;
				r = t.charCodeAt(--e) & 255;
				a = t.charCodeAt(--e) & 255;
				i = t.charCodeAt(--e) & 255;
				n = t.charCodeAt(--e) & 255
			}
			var s = 1 - (r >> 7 << 1);
			var h = (r << 1 & 255 | a >> 7) - 127;
			var c = (a & 127) << 16 | i << 8 | n;
			if (c == 0 && h == -127) return 0;
			return s * (1 + this.TWOeN23 * c) * this.pow(2, h)
		},
		readDouble: function() {
			var t = this.data,
				e, r, a, i, n, s, h, c, d;
			if (this.endian == o.Endian.BIG) {
				e = (this.position += 8) - 8;
				r = t.charCodeAt(e) & 255;
				a = t.charCodeAt(++e) & 255;
				i = t.charCodeAt(++e) & 255;
				n = t.charCodeAt(++e) & 255;
				s = t.charCodeAt(++e) & 255;
				h = t.charCodeAt(++e) & 255;
				c = t.charCodeAt(++e) & 255;
				d = t.charCodeAt(++e) & 255
			} else if (this.endian == o.Endian.LITTLE) {
				e = this.position += 8;
				r = t.charCodeAt(--e) & 255;
				a = t.charCodeAt(--e) & 255;
				i = t.charCodeAt(--e) & 255;
				n = t.charCodeAt(--e) & 255;
				s = t.charCodeAt(--e) & 255;
				h = t.charCodeAt(--e) & 255;
				c = t.charCodeAt(--e) & 255;
				d = t.charCodeAt(--e) & 255
			}
			var u = 1 - (r >> 7 << 1);
			var l = (r << 4 & 2047 | a >> 4) - 1023;
			var f = ((a & 15) << 16 | i << 8 | n).toString(2) + (s >> 7 ? "1" : "0") + ((s & 127) << 24 | h << 16 | c << 8 | d).toString(2);
			f = parseInt(f, 2);
			if (f == 0 && l == -1023) return 0;
			return u * (1 + this.TWOeN52 * f) * this.pow(2, l)
		},
		readUTF: function() {
			var t = this.data;
			var e = this.readUnsignedShort();
			var r = "";
			while (e--) {
				var a = this.readByte();
				r += String.fromCharCode(a)
			}
			return r
		}
	};
	var h = function(t, e) {
			var r = t & 1 << e;
			if (r > 0) return 1;
			else return 0
		};
	var c = function(t) {
			var e = t / (65536 * 65536);
			var r = t - e * 65536 * 65536;
			return r
		};
	var d = ["引航船", "搜救船", "拖轮", "港口供应船", "其他", "执法艇", "其他", "其他", "医疗船", "其他", "捕捞", "拖引", "拖引", "疏浚或水下作业", "潜水作业", "参与军事行动", "帆船航行", "娱乐船", "地效应船", "高速船", "客船", "货船", "油轮", "其他"];
	var u = ["A 类危险品", "B 类危险品", "C 类危险品", "D 类危险品"];
	var l = ["在航(主机推动)", "锚泊", "失控", "操作受限", "吃水受限", "靠泊", "搁浅", "捕捞作业", "靠船帆提供动力"];
	var f = {
		201: "ALB",
		202: "AND",
		203: "AUT",
		204: "AZS",
		205: "BEL",
		206: "BLR",
		207: "BGR",
		208: "VAT",
		209: "CYP",
		210: "CYP",
		211: "DEU",
		212: "CYP",
		213: "GEO",
		214: "MDA",
		215: "MLT",
		216: "ARM",
		218: "DEU",
		219: "DNK",
		220: "DNK",
		224: "ESP",
		225: "ESP",
		226: "FRA",
		227: "FRA",
		228: "FRA",
		230: "FIN",
		231: "FRO",
		232: "GBR",
		233: "GBR",
		234: "GBR",
		235: "GBR",
		236: "GIB",
		237: "GRC",
		238: "HRV",
		239: "GRC",
		240: "GRC",
		242: "MAR",
		243: "HUN",
		244: "NLD",
		245: "NLD",
		246: "NLD",
		247: "ITA",
		248: "MLT",
		249: "MLT",
		250: "IRL",
		251: "ISL",
		252: "LIE",
		253: "LUX",
		254: "MCO",
		255: "MDR",
		256: "MLT",
		257: "NOR",
		258: "NOR",
		259: "NOR",
		261: "POL",
		262: "MNE",
		263: "PRT",
		264: "ROU",
		265: "SWE",
		266: "SWE",
		267: "SVK",
		268: "SMR",
		269: "SWZ",
		270: "CZE",
		271: "TUR",
		272: "UKR",
		273: "RUS",
		274: "MKD",
		275: "LVA",
		276: "EST",
		277: "LTU",
		278: "SVN",
		279: "SRB",
		301: "AIA",
		303: "USA",
		304: "ATG",
		305: "ATG",
		306: "ANT",
		307: "ABW",
		308: "BHS",
		309: "BHS",
		310: "BMU",
		311: "BHS",
		312: "BLZ",
		314: "BRB",
		316: "CAN",
		319: "CYM",
		321: "CRI",
		323: "CUB",
		325: "DOM",
		327: "DOM",
		329: "GLP",
		330: "GRD",
		331: "GRL",
		332: "GTM",
		334: "HND",
		336: "HTI",
		338: "USA",
		339: "JAM",
		341: "KNA",
		343: "LCA",
		345: "MEX",
		347: "MTQ",
		348: "MSR",
		350: "NIC",
		351: "PAN",
		352: "PAN",
		353: "PAN",
		354: "PAN",
		358: "PRI",
		359: "SLV",
		361: "SPM",
		362: "TTO",
		364: "TCA",
		366: "USA",
		367: "USA",
		368: "USA",
		369: "USA",
		371: "PAN",
		372: "PAN",
		375: "VCT",
		376: "VCT",
		377: "VCT",
		378: "VGB",
		379: "VGB",
		401: "AFG",
		403: "SAU",
		405: "BGD",
		408: "BHR",
		410: "BTN",
		412: "CHN",
		413: "CHN",
		414: "CHN",
		416: "TWN",
		417: "LKA",
		419: "IND",
		422: "IRN",
		423: "AZE",
		425: "IRQ",
		428: "ISR",
		431: "JPN",
		432: "JPN",
		434: "TKM",
		436: "KAZ",
		437: "UZB",
		438: "JOR",
		440: "KOR",
		441: "KOR",
		443: "PSE",
		445: "PRK",
		447: "KWT",
		450: "LBN",
		451: "KGZ",
		453: "MAC",
		455: "MDV",
		457: "MNG",
		459: "NPL",
		461: "OMN",
		463: "PAK",
		466: "QAT",
		468: "SYR",
		470: "ARE",
		473: "YEM",
		475: "YEM",
		477: "HKG",
		478: "BIH",
		501: "ADL",
		503: "AUS",
		506: "MMR",
		508: "BRN",
		510: "FSM",
		511: "PLW",
		512: "NZL",
		514: "KHM",
		515: "KHM",
		516: "CXR",
		518: "COK",
		520: "FJI",
		523: "CCK",
		525: "IDN",
		529: "KIR",
		531: "LAO",
		533: "MYS",
		536: "MNP",
		538: "MHL",
		540: "NCL",
		542: "NIU",
		544: "NRU",
		546: "PYF",
		548: "PHL",
		553: "PNG",
		555: "PCN",
		557: "SLB",
		559: "ASM",
		561: "WSM",
		563: "SGP",
		564: "SGP",
		565: "SGP",
		567: "THA",
		570: "TON",
		572: "TUV",
		574: "VNM",
		576: "VUT",
		578: "WLF",
		601: "ZAF",
		603: "AGO",
		605: "DZA",
		607: "ATF",
		608: "ASL",
		609: "BDI",
		610: "BEN",
		611: "BWA",
		612: "CAF",
		613: "CMR",
		615: "COG",
		616: "COM",
		617: "CPV",
		618: "ATF",
		619: "CIV",
		621: "DJI",
		622: "EGY",
		624: "ETH",
		625: "ERI",
		626: "GAB",
		627: "GHA",
		629: "GMB",
		630: "GNB",
		631: "GNQ",
		632: "GIN",
		633: "BFA",
		634: "KEN",
		635: "ATF",
		636: "LBR",
		637: "LBR",
		642: "LBY",
		644: "LSO",
		645: "MUS",
		647: "MDG",
		649: "MLI",
		650: "MOZ",
		654: "MRT",
		655: "MWI",
		656: "NER",
		657: "NGA",
		659: "NAM",
		660: "REU",
		661: "RWA",
		662: "SDN",
		663: "SEN",
		664: "SYC",
		665: "SHN",
		666: "SOM",
		667: "SLE",
		668: "STP",
		669: "SWZ",
		670: "TCD",
		671: "TGO",
		672: "TUN",
		674: "TZA",
		675: "UGA",
		676: "COG",
		677: "TZA",
		678: "ZMB",
		679: "ZWE",
		701: "ARG",
		710: "BRA",
		720: "BOL",
		725: "CHL",
		730: "COL",
		735: "ECU",
		740: "FLK",
		745: "GIN",
		750: "GUY",
		755: "PRY",
		760: "PER",
		765: "SUR",
		770: "URY",
		775: "VEN"
	};
	shipxyAPI = {
		name: "shipxyAPI",
		key: "1F6D701272402D1E7D8D316CCE519123",
		password: "",
		Ship: function() {
			if (this instanceof shipxyAPI.Ship) {
				this.shipId = "";
				this.MMSI = "";
				this.IMO = "";
				this.name = "";
				this.callsign = "";
				this.type = -1;
				this.status = -1;
				this.length = -1;
				this.beam = -1;
				this.left = -1;
				this.trail = -1;
				this.draught = -1;
				this.country = "";
				this.cargoType = "";
				this.lng = 0;
				this.lat = 0;
				this.heading = 0;
				this.course = 0;
				this.speed = -1;
				this.rot = -1;
				this.dest = "";
				this.eta = "";
				this.lastTime = 0
			} else {
				return new shipxyAPI.Ship
			}
		},
		Region: function() {
			if (this instanceof shipxyAPI.Region) {
				this.name = "";
				this.data = null
			} else {
				return new shipxyAPI.Region
			}
		},
		Group: function() {
			if (this instanceof shipxyAPI.Group) {
				this.name = "";
				this.color = "#ffff00";
				this.data = []
			} else {
				return new shipxyAPI.Group
			}
		},
		Track: function(t, e, r) {
			if (this instanceof shipxyAPI.Track) {
				if (!t || !e || !r) {
					throw new Error("shipxyAPI.Track构造方法参数错误，三个参数都不能为空")
				}
				if (typeof t != "string" || typeof e != "number" || typeof r != "number") {
					throw new Error("shipxyAPI.Track构造方法参数类型错误，第一个参数必须为字符串，第二、三个参数必须为数值")
				}
				this.shipId = t;
				this.startTime = e || 0;
				this.endTime = r || 0;
				this.trackId = "track_" + t + "_" + e + "_" + r;
				this.data = null
			} else {
				return new shipxyAPI.Track(t, e, r)
			}
		},
		Ships: function(t, e) {
			if (this instanceof shipxyAPI.Ships) {
				this.data = null;
				this.condition = t;
				this.type = e;
				this.scode = 0
			} else {
				return new shipxyAPI.Ships(t, e)
			}
		},
		AutoShips: function(t, e) {
			if (this instanceof shipxyAPI.AutoShips) {
				shipxyAPI.Ships.call(this, t, e);
				this.interval = 30;
				this.timer = 0
			} else {
				return new shipxyAPI.AutoShips(t, e)
			}
		},
		Search: function() {
			if (this instanceof shipxyAPI.Search) {
				this.data = null
			} else {
				return new shipxyAPI.Search
			}
		},
		Tracks: function() {
			if (this instanceof shipxyAPI.Tracks) {
				this.data = null
			} else {
				return new shipxyAPI.Tracks
			}
		},
		Fleet: function(t) {
			if (this instanceof shipxyAPI.Fleet) {
				this.data = [];
				this.version = 0;
				k.call(this, t)
			} else {
				return new shipxyAPI.Fleet(t)
			}
		},
		login: function(a, i) {
			if (!a) return;
			var s = t + "?v=" + e + "&k=" + shipxyAPI.key + "&enc=" + r + "&cmd=2007&wk=" + a;
			var o = this;
			var h = new n(s, {
				callback: "jsf",
				success: function(t) {
					var e = S.parseStatus(t),
						r = e.status;
					if (r == 0) {
						o.password = a
					}
					i.call(o, g(r))
				},
				error: function() {
					i.call(o, 100)
				}
			});
			h.send()
		},
		modifyPassword: function(a, i) {
			if (!a) return;
			var s = t + "?v=" + e + "&k=" + shipxyAPI.key + "&enc=" + r + "&cmd=2008&wk=" + this.password + "&nwk=" + a;
			var o = this;
			var h = new n(s, {
				callback: "jsf",
				success: function(t) {
					var e = S.parseStatus(t),
						r = e.status;
					if (r == 0) {
						o.password = a
					}
					i.call(o, g(r))
				},
				error: function() {
					i.call(o, 100)
				}
			});
			h.send()
		}
	};
	shipxyAPI.Group.prototype = {
		getShipIds: function() {
			var t = [];
			if (this.data && this.data.length > 0) {
				for (var e = 0, r = this.data.length; e < r; e++) {
					t.push(this.data[e].shipId)
				}
			}
			return t
		},
		getShip: function(t) {
			if (!t) throw new Error("getShip方法参数错误，不能为空，必须指定为一条船的Id");
			var e, r = this.data,
				a = r.length;
			while (a--) {
				e = r[a];
				if (e.shipId == t) return e
			}
			return null
		}
	};
	shipxyAPI.Ships.INIT_SHIPID = 0;
	shipxyAPI.Ships.INIT_REGION = 1;
	shipxyAPI.Ships.INIT_FLEET = 2;
	var p = function(t) {
			if (!t || t.lenght < 3) return "";
			var e = parseInt(t.substr(0, 3));
			if (e == 0 || isNaN(e)) return "";
			return f[e] || ""
		};
	var v = function(t) {
			if (t >= 0 && t <= 8) {
				return l[t]
			}
			return ""
		};
	var A = function(t) {
			if (t < 10 || t > 100) return "";
			var e = Math.floor(t / 10);
			var r = t % 10;
			if (e == 5) {
				return d[r]
			} else if (e == 3) {
				if (r >= 0 && r <= 7) {
					return d[r + 10]
				}
				return ""
			} else {
				switch (e) {
				case 2:
					return d[18];
				case 4:
					return d[19];
				case 6:
					return d[20];
				case 7:
					return d[21];
				case 8:
					return d[22];
				case 9:
					return d[23];
				default:
					return ""
				}
			}
			return ""
		};
	var I = function(t) {
			if (t < 10 || t > 100) return "";
			var e = Math.floor(t / 10);
			var r = t % 10;
			if (e == 5) {
				return ""
			} else if (e == 3) {
				return ""
			} else {
				switch (e) {
				case 2:
				case 4:
				case 6:
				case 7:
				case 8:
				case 9:
					return u[r - 1] || "";
				default:
					return ""
				}
			}
			return ""
		};
	var g = function(t) {
			switch (t) {
			case 0:
				return 0;
			case 6:
				return 1;
			case 7:
			case 9:
				return 2;
			case 14:
				return 3;
			case 12:
			case 15:
				return 4;
			case 16:
				return 5;
			case 17:
				return 6;
			default:
				break
			}
			return 100
		};
	var S = {
		parseShip: function(t) {
			var e = new shipxyAPI.Ship;
			e.shipId = "" + t.readUnsignedInt64();
			t.readUnsignedInt();
			e.MMSI = "" + t.readUnsignedInt();
			e.country = p(e.MMSI);
			var r = t.readUnsignedShort();
			e.type = A(r);
			e.cargoType = I(r);
			var a = t.readUnsignedInt();
			e.IMO = 0 == a || a == 2147483647 ? "" : a.toString();
			e.name = t.readUTF();
			e.callsign = t.readUTF();
			e.length = t.readUnsignedShort() / 10;
			e.length = e.length > 511 ? 511 : e.length;
			e.beam = t.readUnsignedShort() / 10;
			e.left = t.readUnsignedShort() / 10;
			e.trail = t.readUnsignedShort() / 10;
			e.draught = t.readUnsignedShort() / 1e3;
			e.dest = t.readUTF();
			var i = String(t.readByte());
			var n = String(t.readByte());
			var s = String(t.readByte());
			var o = String(t.readByte());
			var h;
			if (i == "0" && n == "0" && s == "0" && o == "0") {
				h = ""
			} else {
				if (s.length == 1) s = "0" + s;
				if (o.length == 1) o = "0" + o;
				h = i + "." + n + " " + s + ":" + o
			}
			e.eta = h;
			e.status = v(t.readUnsignedShort());
			e.lat = t.readInt() / 1e6;
			e.lng = t.readInt() / 1e6;
			e.heading = t.readUnsignedShort() / 100;
			e.course = t.readUnsignedShort() / 100;
			var c = t.readUnsignedShort();
			if (c >= 52576) e.speed = NaN;
			else e.speed = c / 514;
			e.rot = t.readShort() / 100;
			e.lastTime = t.readInt64();
			return e
		},
		parseVectorShip: function(t) {
			var e = {};
			if (r == 0) {
				t = s.decode64(t);
				var a = new o(t, o.Endian.LITTLE);
				try {
					var i = a.readUnsignedInt();
					var n = a.readUnsignedShort();
					e.status = n;
					a.readUnsignedInt();
					if (n == 0) {
						var h = a.readUnsignedInt();
						var c = [];
						while (h--) {
							c.push(this.parseShip(a))
						}
						e.data = c
					}
				} catch (d) {
					e.status = 2
				}
			}
			return e
		},
		parseRegionShip: function(t, e) {
			var a = {};
			if (r == 0) {
				t = s.decode64(t);
				var i = new o(t, o.Endian.LITTLE);
				try {
					var n = i.readUnsignedInt();
					a.status = i.readUnsignedShort();
					if (a.status == 0) {
						var h = i.readInt64();
						a.scode = i.readUnsignedInt();
						var c = i.readUnsignedInt();
						var d = [];
						while (c--) {
							var u = this.parseShip(i);
							if (P({
								lat: u.lat,
								lng: u.lng
							}, e)) {
								d.push(u)
							}
						}
						a.data = d
					}
				} catch (l) {
					a.status = 2
				}
			}
			return a
		},
		parseFleetShip: function(t) {
			var e = {};
			if (r == 0) {
				t = s.decode64(t);
				var a = new o(t, o.Endian.LITTLE);
				try {
					var i = a.readUnsignedInt();
					e.status = a.readUnsignedShort();
					if (e.status == 0) {
						e.scode = a.readUnsignedInt();
						e.version = a.readUnsignedInt();
						var n = a.readUnsignedInt();
						var h = [];
						while (n--) {
							h.push(this.parseShip(a))
						}
						e.data = h
					}
				} catch (c) {
					e.status = 2
				}
			}
			return e
		},
		parseFleet: function(t) {
			var e = {};
			if (r == 0) {
				t = s.decode64(t);
				var a = new o(t, o.Endian.LITTLE);
				try {
					a.readUnsignedInt();
					e.status = a.readUnsignedShort();
					if (e.status == 0) {
						e.version = a.readUnsignedInt();
						var i = a.readUnsignedInt();
						var n = [],
							h;
						while (i--) {
							h = new shipxyAPI.Group;
							h.name = s.utf8to16(a.readUTF());
							var c = a.readUnsignedInt().toString(16);
							c = c.substr(4, 2) + c.substr(2, 2) + c.substr(0, 2);
							var d = 6 - c.length;
							while (d--) {
								c += 0
							}
							h.color = "#" + c;
							var u = a.readUnsignedInt();
							var l = [],
								f;
							while (u--) {
								f = {};
								f.shipId = "" + a.readUnsignedInt64();
								f.customName = s.utf8to16(a.readUTF());
								f.remarks = s.utf8to16(a.readUTF());
								l.push(f)
							}
							h.data = l;
							n.push(h)
						}
						e.data = n
					}
				} catch (p) {
					e.status = 2
				}
			}
			return e
		},
		parseSearchShip: function(t, e) {
			var a = {};
			if (r == 0) {
				t = s.decode64(t);
				var i = new o(t, o.Endian.LITTLE);
				try {
					var n = i.readUnsignedInt();
					a.status = i.readUnsignedShort();
					if (a.status == 0) {
						var h = i.readUnsignedInt();
						var c = [],
							d;
						while (h--) {
							d = {};
							var u = i.readByte();
							if (e == 0) {
								d.shipId = "" + i.readUnsignedInt64();
								var l = i.readUnsignedInt();
								d.MMSI = "" + i.readUnsignedInt();
								d.country = p(d.MMSI);
								var f = i.readUnsignedShort();
								d.IMO = i.readUnsignedInt();
								d.name = i.readUTF();
								d.callsign = i.readUTF();
								var v = i.readInt64()
							} else if (e == 1) {}
							c.push(d)
						}
						a.data = c
					}
				} catch (A) {
					a.status = 2
				}
			}
			return a
		},
		parseTrack: function(t) {
			var e = {};
			if (r == 0) {
				t = s.decode64(t);
				var a = new o(t, o.Endian.LITTLE);
				try {
					var i = a.readUnsignedInt();
					e.status = a.readUnsignedShort();
					if (e.status == 0) {
						var n = a.readUnsignedInt();
						var h = [],
							c;
						while (n--) {
							c = {};
							c.lastTime = a.readInt64();
							c.from = a.readUnsignedShort();
							c.lng = a.readInt() / 1e6;
							c.lat = a.readInt() / 1e6;
							var d = a.readShort();
							if (d >= 52576) c.speed = NaN;
							else c.speed = d / 514;
							c.course = a.readShort() / 100;
							h.push(c)
						}
						e.data = h;
						e["continue"] = a.readUnsignedShort()
					}
				} catch (u) {
					e.status = 2
				}
			}
			return e
		},
		parseStatus: function(t) {
			var e = {};
			if (r == 0) {
				t = s.decode64(t);
				var a = new o(t, o.Endian.LITTLE);
				try {
					var i = a.readUnsignedInt();
					e.status = a.readUnsignedShort()
				} catch (n) {
					e.status = 2
				}
			}
			return e
		}
	};
	var C = function(a, i) {
			var s = t + "?v=" + e + "&k=" + shipxyAPI.key + "&enc=" + r + "&cmd=2003&id=" + a;
			var o = this;
			var h = new n(s, {
				callback: "jsf",
				success: function(t) {
					var e = S.parseVectorShip(t),
						r = e.status;
					if (r == 0) {
						o.data = e.data
					}
					i.call(o, g(r))
				},
				error: function() {
					i.call(o, 100)
				}
			});
			h.send()
		};
	var y = function(a, i) {
			var s = t + "?v=" + e + "&k=" + shipxyAPI.key + "&enc=" + r + "&cmd=2003&id=" + a.toString();
			var o = this;
			var h = new n(s, {
				callback: "jsf",
				success: function(t) {
					var e = S.parseVectorShip(t),
						r = e.status;
					if (r == 0) {
						o.data = e.data
					}
					i.call(o, g(r))
				},
				error: function() {
					i.call(o, 100)
				}
			});
			h.send()
		};
	var w = function(a, i) {
			var s = a.data;
			if (!s && s.length < 3) throw new Error("区域必须是有效的多边形，不能少于三个点");
			var o = "",
				h = 0,
				c = s.length,
				d;
			for (; h < c; h++) {
				d = s[h];
				if (h > 0) o += "-";
				o += d.lng * 1e6 + "," + d.lat * 1e6
			}
			var u = t + "?v=" + e + "&k=" + shipxyAPI.key + "&enc=" + r + "&cmd=2004&mode=0&scode=" + this.scode + "&xy=" + o;
			var l = this;
			var f = new n(u, {
				callback: "jsf",
				success: function(t) {
					var e = S.parseRegionShip(t, s),
						r = e.status;
					if (r == 0) {
						l.data = e.data;
						l.scode = e.scode
					}
					i.call(l, g(r))
				},
				error: function() {
					i.call(l, 100)
				}
			});
			f.send()
		};
	var T = function(t, e) {};
	var m = function(a, i) {
			var s = t + "?v=" + e + "&k=" + shipxyAPI.key + "&enc=" + r + "&cmd=2006&dv=" + this.scode + "&fv=" + a.version;
			var o = this;
			var h = new n(s, {
				callback: "jsf",
				success: function(t) {
					var e = S.parseFleetShip(t),
						r = e.status;
					if (r == 0) {
						o.data = e.data;
						o.scode = e.scode;
						a.version = e.version
					}
					i.call(o, g(r))
				},
				error: function() {
					i.call(o, 100)
				}
			});
			h.send()
		};
	var k = function(a) {
			var i = t + "?v=" + e + "&k=" + shipxyAPI.key + "&enc=" + r + "&cmd=1000";
			var s = this;
			var o = new n(i, {
				callback: "jsf",
				success: function(t) {
					var e = S.parseFleet(t),
						r = e.status;
					if (r == 0) {
						s.version = e.version;
						s.data = e.data
					}
					a.call(s, g(r))
				},
				error: function() {
					a.call(s, 100)
				}
			});
			o.send()
		};
	shipxyAPI.Ships.prototype = {
		getShips: function(t) {
			switch (this.type) {
			case shipxyAPI.Ships.INIT_SHIPID:
				if (typeof this.condition == "string") {
					C.call(this, this.condition, t)
				} else if (this.condition instanceof Array) {
					y.call(this, this.condition, t)
				}
				break;
			case shipxyAPI.Ships.INIT_REGION:
				if (this.condition instanceof shipxyAPI.Region) {
					w.call(this, this.condition, t)
				} else if (this.condition instanceof Array) {
					T.call(this, this.condition, t)
				}
				break;
			case shipxyAPI.Ships.INIT_FLEET:
				m.call(this, this.condition, t);
				break
			}
		}
	};
	a(shipxyAPI.AutoShips, shipxyAPI.Ships, {
		setAutoUpdateInterval: function(t) {
			if (typeof t == "number" && !isNaN(t)) {
				if (t < 30) t = 30;
				this.interval = t
			}
		},
		startAutoUpdate: function(t) {
			var e = this;
			this.timer = setInterval(function() {
				e.getShips.call(e, t)
			}, this.interval * 1e3)
		},
		stopAutoUpdate: function() {
			clearInterval(this.timer);
			this.timer = 0
		}
	});
	shipxyAPI.Search.prototype = {
		searchShip: function(a, i) {
			var s = t + "?v=" + e + "&k=" + shipxyAPI.key + "&enc=" + r + "&cmd=2001&kw=" + a.keyword + "&tp=" + (a.type || 0) + "&max=" + (a.max || 20);
			var o = this;
			var h = new n(s, {
				callback: "jsf",
				success: function(t) {
					var e = S.parseSearchShip(t, a.type || 0),
						r = e.status;
					if (r == 0) {
						o.data = e.data
					} else {
						o.data = null
					}
					i.call(o, g(r))
				},
				error: function() {
					o.data = null;
					i.call(o, 100)
				}
			});
			h.send()
		}
	};
	shipxyAPI.Tracks.prototype = {
		getTrack: function(a, i, s, o) {
			var h = t + "?v=" + e + "&k=" + shipxyAPI.key + "&enc=" + r + "&cmd=2005&cut=1&id=" + a + "&btm=" + i + "&etm=" + s;
			var c = this;
			this.request = new n(h, {
				callback: "jsf",
				timeout: 3e4,
				success: function(t) {
					delete c.request;
					var e = S.parseTrack(t),
						r = e.status;
					if (r == 0) {
						if (!c.data) {
							c.data = new shipxyAPI.Track(a, i, s);
							c.data.data = e.data
						} else {
							c.data.data = c.data.data.concat(e.data)
						}
						if (e["continue"] == 1) {
							c.getTrack(a, e.data[e.data.length - 1].lastTime, s, o);
							return
						}
					} else {
						c.data = null
					}
					o.call(c, g(r))
				},
				error: function() {
					delete c.request;
					c.data = null;
					o.call(c, 100)
				}
			});
			this.request.send()
		},
		abort: function() {
			if (this.request) {
				this.request.abort();
				this.data = null;
				delete this.request
			}
		}
	};
	shipxyAPI.Fleet.prototype = {
		getGroup: function(t) {
			var e, r = this.data.length;
			while (r--) {
				e = this.data[r];
				if (e.name == t) return e
			}
			return null
		},
		getGroupsByShipId: function(t) {
			var e, r, a = [];
			for (var i = 0, n = this.data.length; i < n; i++) {
				e = this.data[i];
				r = e.getShipIds();
				for (var s = 0, o = r.length; s < o; s++) {
					if (r[s] == t) {
						a.push(e);
						break
					}
				}
			}
			return a
		},
		addGroup: function(a, i) {
			if (!(a instanceof shipxyAPI.Group)) throw new Error("addGroup方法的第一个参数必须是shipxyAPI.Group实例");
			var s = a.color;
			s = parseInt("0x" + s.substr(1, 2)) + "," + parseInt("0x" + s.substr(3, 2)) + "," + parseInt("0x" + s.substr(5, 2));
			var o = t + "?v=" + e + "&k=" + shipxyAPI.key + "&enc=" + r + "&cmd=1001&gn=" + a.name + "&gc=" + s + "&wk=" + shipxyAPI.password;
			var h = this;
			var c = new n(o, {
				callback: "jsf",
				success: function(t) {
					var e = S.parseStatus(t),
						r = e.status;
					if (r == 0) {
						h.data.push(a)
					}
					i.call(h, g(r))
				},
				error: function() {
					i.call(h, 100)
				}
			});
			c.send()
		},
		modifyGroup: function(a, i, s) {
			if (typeof a == "string") a = this.getGroup(a);
			if (!a) throw new Error("modifyGroup方法的第一个参数错误，没有找到该组");
			if (!i) throw new Error("modifyGroup方法的第二个参数必须是不能为空，且应该指定组名和/或组颜色属性");
			var o = i.color || a.color,
				h, c = i.name || a.name;
			if (o) h = parseInt("0x" + o.substr(1, 2)) + "," + parseInt("0x" + o.substr(3, 2)) + "," + parseInt("0x" + o.substr(5, 2));
			var d = t + "?v=" + e + "&k=" + shipxyAPI.key + "&enc=" + r + "&cmd=1002&gn=" + a.name + "&gc=" + h + "&ngn=" + c + "&wk=" + shipxyAPI.password;
			var u = this;
			var l = new n(d, {
				callback: "jsf",
				success: function(t) {
					var e = S.parseStatus(t),
						r = e.status;
					if (r == 0) {
						if (c) a.name = c;
						if (o) a.color = o
					}
					s.call(u, g(r))
				},
				error: function() {
					s.call(u, 100)
				}
			});
			l.send()
		},
		delGroup: function(a, i) {
			if (typeof a == "string") a = this.getGroup(a);
			if (!a) throw new Error("delGroup方法的第一个参数错误，没有找到该组");
			var s = t + "?v=" + e + "&k=" + shipxyAPI.key + "&enc=" + r + "&cmd=1003&gn=" + a.name + "&wk=" + shipxyAPI.password;
			var o = this;
			var h = new n(s, {
				callback: "jsf",
				success: function(t) {
					var e = S.parseStatus(t),
						r = e.status;
					if (r == 0) {
						var n = o.data.length;
						while (n--) {
							if (o.data[n] == a) {
								o.data.splice(n, 1);
								break
							}
						}
					}
					i.call(o, g(r))
				},
				error: function() {
					i.call(o, 100)
				}
			});
			h.send()
		},
		addShip: function(a, i, s) {
			if (!a) throw new Error("addShip方法的第一个参数必须是不能为空，且应该指定船舶Id和/或自定义船名、备注属性");
			var o = a.shipId;
			if (!o) throw new Error("addShip方法的第一个参数必须包含船舶Id属性");
			if (typeof i == "string") i = this.getGroup(i);
			if (!i) throw new Error("addShip方法的第二个参数错误，没有找到该组");
			var h = a.customName || "",
				c = a.remarks || "";
			var d = t + "?v=" + e + "&k=" + shipxyAPI.key + "&enc=" + r + "&cmd=1004&gn=" + i.name + "&id=" + o + "&cn=" + h + "&rmk=" + c + "&wk=" + shipxyAPI.password;
			var u = this;
			var l = new n(d, {
				callback: "jsf",
				success: function(t) {
					var e = S.parseStatus(t),
						r = e.status;
					if (r == 0) {
						i.data.push({
							shipId: o,
							customName: h,
							remarks: c
						})
					}
					s.call(u, g(r))
				},
				error: function() {
					s.call(u, 100)
				}
			});
			l.send()
		},
		modifyShip: function(a, i, s) {
			if (!a) throw new Error("modifyShip方法的第一个参数必须是不能为空，且应该指定船舶Id和/或自定义船名、备注属性");
			var o = a.shipId;
			if (!a.shipId) throw new Error("modifyShip方法的第一个参数必须包含船舶Id属性");
			if (typeof i == "string") i = this.getGroup(i);
			if (!i) throw new Error("modifyShip方法的第二个参数错误，没有找到该组");
			var h = a.customName || "",
				c = a.remarks || "";
			var d = t + "?v=" + e + "&k=" + shipxyAPI.key + "&enc=" + r + "&cmd=1004&gn=" + i.name + "&id=" + o + "&cn=" + h + "&rmk=" + c + "&wk=" + shipxyAPI.password;
			var u = this;
			var l = new n(d, {
				callback: "jsf",
				success: function(t) {
					var e = S.parseStatus(t),
						r = e.status;
					if (r == 0) {
						var a = i.getShip(o);
						if (!a) i.data.push({
							shipId: o,
							customName: h,
							remarks: c
						});
						else {
							a.customName = h;
							a.remarks = c
						}
					}
					s.call(u, g(r))
				},
				error: function() {
					s.call(u, 100)
				}
			});
			l.send()
		},
		delShip: function(a, i, s) {
			if (!a) throw new Error("delShip方法的第一个参数不能为空，必须指定为船舶Id");
			if (typeof i == "string") i = this.getGroup(i);
			if (!i) throw new Error("modifyShip方法的第二个参数错误，没有找到该组");
			var o = t + "?v=" + e + "&k=" + shipxyAPI.key + "&enc=" + r + "&cmd=1005&gn=" + i.name + "&id=" + a + "&wk=" + shipxyAPI.password;
			var h = this;
			var c = new n(o, {
				callback: "jsf",
				success: function(t) {
					var e = S.parseStatus(t),
						r = e.status;
					if (r == 0) {
						var n = i.data,
							o = n.length;
						while (o--) {
							if (n[o].shipId == a) {
								n.splice(o, 1);
								break
							}
						}
					}
					s.call(h, g(r))
				},
				error: function() {
					s.call(h, 100)
				}
			});
			c.send()
		}
	};
	var P = function(t, e) {
			var r, a, i, n, s, o, h = 0,
				c, d, u, l, f = e.length;
			for (r = 1; r <= f; r++) {
				if (r == f) {
					a = e[0];
					i = e[f - 1];
					if (a.lat == i.lat && a.lng == i.lng) continue
				} else {
					a = e[r];
					i = e[r - 1]
				}
				if (a.lng < t.lng && i.lng < t.lng) continue;
				if (t.lat == i.lat && t.lng == i.lng) return false;
				if (a.lat == t.lat && i.lat == t.lat) {
					n = a.lng;
					s = i.lng;
					if (n > s) {
						n = i.lng;
						s = a.lng
					}
					if (t.lng >= n && t.lng <= s) return false;
					continue
				}
				if (a.lat > t.lat && i.lat <= t.lat || i.lat > t.lat && a.lat <= t.lat) {
					c = a.lng - t.lng;
					d = a.lat - t.lat;
					u = i.lng - t.lng;
					l = i.lat - t.lat;
					o = E(c, d, u, l);
					if (o == 0) return false;
					if (l < d) o = -o;
					if (o > 0) h++
				}
			}
			return h % 2 == 1
		};
	var E = function(t, e, r, a) {
			var i = 1,
				n, s;
			if (t == 0 || a == 0) {
				if (e == 0 || r == 0) {
					return 0
				} else if (e > 0) {
					if (r > 0) {
						return -i
					} else {
						return i
					}
				} else {
					if (r > 0) {
						return i
					} else {
						return -i
					}
				}
			}
			if (e == 0 || r == 0) {
				if (a > 0) {
					if (t > 0) {
						return i
					} else {
						return -i
					}
				} else {
					if (t > 0) {
						return -i
					} else {
						return i
					}
				}
			}
			if (0 < e) {
				if (0 < a) {
					if (e <= a) {} else {
						i = -i;
						n = t;
						t = r;
						r = n;
						n = e;
						e = a;
						a = n
					}
				} else {
					if (e <= -a) {
						i = -i;
						r = -r;
						a = -a
					} else {
						n = t;
						t = -r;
						r = n;
						n = e;
						e = -a;
						a = n
					}
				}
			} else {
				if (0 < a) {
					if (-e <= a) {
						i = -i;
						t = -t;
						e = -e
					} else {
						n = -t;
						t = r;
						r = n;
						n = -e;
						e = a;
						a = n
					}
				} else {
					if (e >= a) {
						t = -t;
						e = -e;
						r = -r;
						a = -a
					} else {
						i = -i;
						n = -t;
						t = -r;
						r = n;
						n = -e;
						e = -a;
						a = n
					}
				}
			}
			if (0 < t) {
				if (0 < r) {
					if (t <= r) {} else {
						return i
					}
				} else {
					return i
				}
			} else {
				if (0 < r) {
					return -i
				} else {
					if (t >= r) {
						i = -i;
						t = -t;
						r = -r
					} else {
						return -i
					}
				}
			}
			while (true) {
				s = Math.floor(r / t);
				r = r - s * t;
				a = a - s * e;
				if (a < 0) {
					return -i
				}
				if (a > e) {
					return i
				}
				if (t > r + r) {
					if (e < a + a) {
						return i
					}
				} else {
					if (e > a + a) {
						return -i
					} else {
						r = t - r;
						a = e - a;
						i = -i
					}
				}
				if (a == 0) {
					if (r == 0) {
						return 0
					} else {
						return -i
					}
				}
				if (r == 0) {
					return i
				}
				s = Math.floor(t / r);
				t = t - s * r;
				e = e - s * a;
				if (e < 0) {
					return i
				}
				if (e > a) {
					return -i
				}
				if (r > t + t) {
					if (a < e + e) {
						return -i
					}
				} else {
					if (a > e + e) {
						return i
					} else {
						t = r - t;
						e = a - e;
						i = -i
					}
				}
				if (e == 0) {
					if (t == 0) {
						return 0
					} else {
						return i
					}
				}
				if (t == 0) {
					return -i
				}
			}
			return 0
		}
}();