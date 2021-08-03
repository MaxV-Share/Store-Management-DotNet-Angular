export * from "./bases";
export * from "./constants";
export * from "./create-requests";
export * from "./update-requests";
export * from "./view-models";
export * from "./environment";
export * from "./login";
export * from "./register";

import { createMapper } from '@automapper/core';
import { classes } from '@automapper/classes';

export const mapper = createMapper({
    name: 'someName',
    pluginInitializer: classes,
  });

