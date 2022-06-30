import React from 'react';
import clsx from 'clsx';
import Layout from '@theme/Layout';
import Link from '@docusaurus/Link';
import useDocusaurusContext from '@docusaurus/useDocusaurusContext';
import styles from './index.module.css';
import HomepageFeatures from '../components/HomepageFeatures';
import {useColorMode} from '@docusaurus/theme-common';
import Logo from '@site/static/img/logo.png';
import LogoDark from '@site/static/img/logo-dark.png';
import Translate, { translate } from '@docusaurus/Translate';

function HomepageHeader() {
  const { siteConfig } = useDocusaurusContext();
  const { isDarkTheme } = useColorMode();
  return (
    <header className={clsx('hero hero--primary', styles.heroBanner)}>
      <div className="container">
        <img src={isDarkTheme ? LogoDark : Logo} width='20%'/>
        <p className="hero__subtitle">
          <Translate id="homepage.tagline">
            Perfect Union of mods.
          </Translate>
        </p>
        <div className={styles.buttons}>
          <Link
            className="button button--secondary button--lg"
            to="/docs/intro">
            <Translate id="homepage.button"
              description="The big button in the center on the home page">
              See the pages
            </Translate>
          </Link>
        </div>
      </div>
    </header>
  );
}

export default function Home() {
  const {siteConfig} = useDocusaurusContext();
  return (
    <Layout
      title={`${siteConfig.title}`}
      description="Traveler's Bag Build or Mod-Union - Streets of Rogue big project-mod, who unite MTP and SMaD and other future mods.">
      <HomepageHeader/>
      <main>
        <HomepageFeatures/>
      </main>
    </Layout>
  );
}
