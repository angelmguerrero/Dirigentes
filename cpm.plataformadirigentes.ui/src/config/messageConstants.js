
import * as allMessage from "./message";
import * as allMessageLogin from "./messageLogin";
import * as allCongig from './auth'

const messageConstants = {
  ...allMessage,
  ...allMessageLogin,
  ...allCongig
};

messageConstants.install = function (Vue) {
  Vue.prototype.$messageConstants = (key) => {
    return messageConstants[key];
  };
};

export default messageConstants;