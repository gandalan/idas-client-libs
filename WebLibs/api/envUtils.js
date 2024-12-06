/**
 * @typedef {Object} EnvironmentConfig
 * @property {string} name - The environment name.
 * @property {string} version - The version number.
 * @property {string} cms - The CMS URL.
 * @property {string} idas - The IDAS API URL.
 * @property {string} store - The store API URL.
 * @property {string} docs - The documentation URL.
 * @property {string} notify - The notification service URL.
 * @property {string} feedback - The feedback service URL.
 * @property {string} helpcenter - The help center URL.
 * @property {string} reports - The reports service URL.
 * @property {string} webhookService - The webhook service URL.
 */

/**
 * buffer for environment data
 * @private
 * @type {Object.<string, EnvironmentConfig>}
 */
const envs = {};

/**
 * Fetches the environment data from the hub.
 *
 * @export
 * @async
 * @param {string} [env=""] - The environment name (e.g., "dev", "staging", "produktiv").
 * @returns {Promise<EnvironmentConfig>}
 */
export async function fetchEnv(env = "") {
  if (!(env in envs)) {
    const hubUrl = `https://connect.idas-cloudservices.net/api/Endpoints?env=${env}`;
    console.log("fetching env", hubUrl);
    const r = await fetch(hubUrl);
    const data = await r.json();
    envs[env] = data;
  }
  return envs[env];
}
