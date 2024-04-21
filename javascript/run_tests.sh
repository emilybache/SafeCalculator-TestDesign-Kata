#!/bin/sh
set -e

npm install -g yarn
yarn install
yarn test
