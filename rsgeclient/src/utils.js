function tranformToUnicode(str) {
    var tmp = "";
    for (var i = 0; i < str.length; i++) {
        switch (str.charCodeAt(i)) {
            case 94:
                tmp += String.fromCharCode(4304);
                break;
            case 96:
                tmp += String.fromCharCode(4305);
                break;
            case 124:
                tmp += String.fromCharCode(4306);
                break;
            case 126:
                tmp += String.fromCharCode(4307);
                break;
            case 166:
                tmp += String.fromCharCode(4308);
                break;
            case 164:
                tmp += String.fromCharCode(4309);
                break;
            case 1169:
                tmp += String.fromCharCode(4310);
                break;
            case 1027:
                tmp += String.fromCharCode(4311);
                break;
            case 1107:
                tmp += String.fromCharCode(4312);
                break;
            case 1026:
                tmp += String.fromCharCode(4313);
                break;
            case 1106:
                tmp += String.fromCharCode(4314);
                break;
            case 1028:
                tmp += String.fromCharCode(4315);
                break;
            case 1108:
                tmp += String.fromCharCode(4316);
                break;
            case 1029:
                tmp += String.fromCharCode(4317);
                break;
            case 1109:
                tmp += String.fromCharCode(4318);
                break;
            case 1030:
                tmp += String.fromCharCode(4319);
                break;
            case 1110:
                tmp += String.fromCharCode(4320);
                break;
            case 1031:
                tmp += String.fromCharCode(4321);
                break;
            case 1111:
                tmp += String.fromCharCode(4322);
                break;
            case 1032:
                tmp += String.fromCharCode(4323);
                break;
            case 1112:
                tmp += String.fromCharCode(4324);
                break;
            case 1036:
                tmp += String.fromCharCode(4325);
                break;
            case 1116:
                tmp += String.fromCharCode(4326);
                break;
            case 1033:
                tmp += String.fromCharCode(4327);
                break;
            case 1113:
                tmp += String.fromCharCode(4328);
                break;
            case 1034:
                tmp += String.fromCharCode(4329);
                break;
            case 1114:
                tmp += String.fromCharCode(4330);
                break;
            case 1035:
                tmp += String.fromCharCode(4331);
                break;
            case 1115:
                tmp += String.fromCharCode(4332);
                break;
            case 1038:
                tmp += String.fromCharCode(4333);
                break;
            case 1118:
                tmp += String.fromCharCode(4334);
                break;
            case 1039:
                tmp += String.fromCharCode(4335);
                break;
            case 1119:
                tmp += String.fromCharCode(4336);
                break;
            case 32:
                tmp += String.fromCharCode(160);
                break;
            default:
                tmp += str[i];

        }

    }
    return tmp;
}

function transformFromUnicode(str) {
    var tmp = "";
    for (var i = 0; i < str.length; i++) {
        switch (str.charCodeAt(i)) {
            case 4304:
                tmp += String.fromCharCode(94);
                break; 
            case 4305:
                tmp += String.fromCharCode(96);
                break;
            case 4306:
                tmp += String.fromCharCode(124);
                break;
            case 4307:
                tmp += String.fromCharCode(126);
                break;
            case 4308:
                tmp += String.fromCharCode(166);
                break;
            case 4309:
                tmp += String.fromCharCode(164);
                break;
            case 4310:
                tmp += String.fromCharCode(1169);
                break;
            case 4311:
                tmp += String.fromCharCode(1027);
                break;
            case 4312:
                tmp += String.fromCharCode(1107);
                break;
            case 4313:
                tmp += String.fromCharCode(1026);
                break;
            case 4314:
                tmp += String.fromCharCode(1106);
                break;
            case 4315:
                tmp += String.fromCharCode(1028);
                break;
            case 4316:
                tmp += String.fromCharCode(1108);
                break;
            case 4317:
                tmp += String.fromCharCode(1029);
                break;
            case 4318:
                tmp += String.fromCharCode(1109);
                break;
            case 4319:
                tmp += String.fromCharCode(1030);
                break;
            case 4320:
                tmp += String.fromCharCode(1110);
                break;
            case 4321:
                tmp += String.fromCharCode(1031);
                break;
            case 4322:
                tmp += String.fromCharCode(1111);
                break;
            case 4323:
                tmp += String.fromCharCode(1032);
                break;
            case 4324:
                tmp += String.fromCharCode(1112);
                break;
            case 4325:
                tmp += String.fromCharCode(1036);
                break;
            case 4326:
                tmp += String.fromCharCode(1116);
                break;
            case 4327:
                tmp += String.fromCharCode(1033);
                break;
            case 4328:
                tmp += String.fromCharCode(1113);
                break;
            case 4329:
                tmp += String.fromCharCode(1034);
                break;
            case 4330:
                tmp += String.fromCharCode(1114);
                break;
            case 4331:
                tmp += String.fromCharCode(1035);
                break;
            case 4332:
                tmp += String.fromCharCode(1115);
                break;
            case 4333:
                tmp += String.fromCharCode(1038);
                break;
            case 4334:
                tmp += String.fromCharCode(1118);
                break;
            case 4335:
                tmp += String.fromCharCode(1039);
                break;
            case 4336:
                tmp += String.fromCharCode(1119);
                break;
            default:
                tmp += str[i];

        }

    }
    return tmp;
}


export default {
    tranformToUnicode,
    transformFromUnicode
}