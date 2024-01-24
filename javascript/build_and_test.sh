#! /bin/sh

set -e

npm install --global yarn
yarn install
yarn test
