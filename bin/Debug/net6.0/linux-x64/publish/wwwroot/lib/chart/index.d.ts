export * from './controllers/index.js.js';
export * from './core/index.js.js';
export * from './elements/index.js.js';
export * from './platform/index.js.js';
export * from './plugins/index.js.js';
export * from './scales/index.js.js';
import * as controllers from './controllers/index.js.js';
import * as elements from './elements/index.js.js';
import * as plugins from './plugins/index.js.js';
import * as scales from './scales/index.js.js';
export { controllers, elements, plugins, scales, };
export declare const registerables: (typeof controllers | typeof elements | typeof plugins | typeof scales)[];
